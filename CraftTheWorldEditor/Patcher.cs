using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CraftTheWorldEditor
{
    internal static class Patcher
    {
        #region Helper

        private static void AppendPatchChange(XmlDocument doc, string section, string name, string type, string to)
        {
            if (doc == null)
            {
                return;
            }

            XmlNode patchNode = doc["patch"];

            XmlNode sectionNode = patchNode[section];
            if (sectionNode == null)
            {
                sectionNode = doc.AppendElement(patchNode, section);
            }

            XmlNode node = sectionNode.SelectSingleNode("//change[@name='" + name + "'][@type='" + type + "']");
            if (node == null)
            {
                node = doc.AppendElement(sectionNode, "change");
            }

            doc.ChangeOrAddAttribute(node, "name", name);
            doc.ChangeOrAddAttribute(node, "type", type);
            doc.ChangeOrAddAttribute(node, "to", to);
        }
        private static void AppendPatchChangeText(XmlDocument doc, string section, string name, string to)
        {
            if (doc == null)
            {
                return;
            }

            XmlNode patchNode = doc["patch"];

            XmlNode sectionNode = patchNode[section];
            if (sectionNode == null)
            {
                sectionNode = doc.AppendElement(patchNode, section);
            }

            XmlNode node = sectionNode.SelectSingleNode("//change[@name='" + name + "']");
            if (node == null)
            {
                node = doc.AppendElement(sectionNode, "change");
                doc.ChangeOrAddAttribute(node, "name", name);

                XmlCDataSection data = doc.CreateCDataSection(to);
                node.AppendChild(data);
            }
            else
            {
                XmlCDataSection data = (XmlCDataSection)node.ChildNodes[0];
                data.InnerText = to;
            }
        }

        #endregion

        #region Methods

        public static Task<bool> PatchWorldSettings(ZipArchive archive, List<WorldSettingChange> changes, IProgress<string> log, XmlDocument patchInfo)
        {
            return Task.Factory.StartNew(() =>
            {
                log.Report("Patche Welt Einstellungen..");

                ZipArchiveEntry entry = archive.GetEntry(ArchiveEntries.WorldSettings);
                if (entry != null)
                {
                    using (Stream stream = entry.Open())
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(stream);

                        bool hasChanges = false;
                        foreach (XmlNode node in doc.SelectNodes("root/param"))
                        {
                            string name = node.Attributes["name"].InnerText;
                            string value = node.Attributes["value"].InnerText;

                            WorldSettingChange change = changes.FirstOrDefault(m => m.Name == name);
                            if (change != null && change.Value != value)
                            {
                                hasChanges = true;

                                log.Report($"Schreibe {change.Name}..");

                                node.Attributes["value"].InnerText = change.Value;
                                AppendPatchChange(patchInfo, "WorldSettings", name, "value", change.Value);
                            }
                        }

                        if (hasChanges)
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            doc.Save(stream);
                            stream.SetLength(stream.Position);
                            stream.Flush();
                        }
                        else
                        {
                            log.Report("Keine Änderungen gefunden");
                        }
                    }

                }
                else
                {
                    log.Report($"Element {ArchiveEntries.WorldSettings} nicht gefunden");
                }

                return true;
            });
        }

        public static Task<bool> PatchCraftResources(ZipArchive archive, List<ResourceItemChange> changes,
            IProgress<string> log, XmlDocument patchInfo)
        {
            return Task.Factory.StartNew(() =>
            {
                log.Report("Patche Gegenstände..");

                ZipArchiveEntry entry = archive.GetEntry(ArchiveEntries.CraftResources);
                if (entry != null)
                {
                    using (Stream stream = entry.Open())
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(stream);

                        bool hasChanges = false;
                        foreach (XmlNode node in doc.SelectNodes("root/resource"))
                        {
                            string name = node.Attributes["name"].InnerText;

                            var items = changes.Where(m => m.Name == name).ToArray();
                            if (items.Length > 0)
                            {
                                var propertyChange = items.FirstOrDefault(m => m.Type == "properties");
                                if (node.Attributes["properties"] != null && propertyChange != null)
                                {
                                    string properties = node.Attributes["properties"].InnerText;
                                    if (propertyChange.Value != properties)
                                    {
                                        hasChanges = true;

                                        node.Attributes["properties"].InnerText = propertyChange.Value;
                                        AppendPatchChange(patchInfo, "CraftResources", name, "properties", propertyChange.Value);

                                        log.Report($"Schreibe Eigenschaften für {name}..");
                                    }
                                }

                                var shopCountChange = items.FirstOrDefault(m => m.Type == "shop_count");
                                if (node.Attributes["shop_count"] != null)
                                {
                                    string shop_count = node.Attributes["shop_count"].InnerText;
                                    if (shopCountChange.Value != shop_count)
                                    {
                                        hasChanges = true;

                                        node.Attributes["shop_count"].InnerText = shopCountChange.Value;
                                        AppendPatchChange(patchInfo, "CraftResources", name, "shop_count", shopCountChange.Value);

                                        log.Report($"Schreibe Shop Anzahl für {name}..");
                                    }
                                }

                                var shopCostChange = items.FirstOrDefault(m => m.Type == "shop_cost");
                                if (node.Attributes["shop_cost"] != null)
                                {
                                    string shop_cost = node.Attributes["shop_cost"].InnerText;
                                    if (shopCostChange.Value != shop_cost)
                                    {
                                        hasChanges = true;

                                        node.Attributes["shop_cost"].InnerText = shopCostChange.Value;
                                        AppendPatchChange(patchInfo, "CraftResources", name, "shop_cost", shopCostChange.Value);

                                        log.Report($"Schreibe Shop Preis Anzahl für {name}..");
                                    }
                                }
                            }
                        }

                        if (hasChanges)
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            doc.Save(stream);
                            stream.SetLength(stream.Position);
                            stream.Flush();
                        }
                        else
                        {
                            log.Report("Keine Änderungen gefunden");
                        }
                    }
                }
                else
                {
                    log.Report($"Element {ArchiveEntries.CraftResources} nicht gefunden");
                }

                return true;
            });
        }

        public static Task<bool> PatchCharLevels(ZipArchive archive, string change, IProgress<string> log, XmlDocument patchInfo)
        {
            return Task.Factory.StartNew(() =>
            {
                log.Report("Patche Erfahrungspunkte..");

                ZipArchiveEntry entry = archive.GetEntry(ArchiveEntries.CharLevels);
                if (entry != null)
                {
                    string charLevels = entry.ReadString();
                    if (charLevels != change)
                    {
                        log.Report($"Schreibe Level..");

                        entry.SetString(change);
                        AppendPatchChangeText(patchInfo, "CharLevels", "Content", change);
                    }
                    else
                    {
                        log.Report("Keine Änderungen gefunden");
                    }
                }
                else
                {
                    log.Report($"Element {ArchiveEntries.CharLevels} nicht gefunden");
                }

                return true;
            });
        }

        public static Task<bool> PatchExperienceSettings(ZipArchive archive, List<ExperienceSettingChange> changes, IProgress<string> log, XmlDocument patchInfo)
        {
            return Task.Factory.StartNew(() =>
            {
                log.Report("Patche Erfahrungspunkte..");

                ZipArchiveEntry entry = archive.GetEntry(ArchiveEntries.ExperienceSettings);
                if (entry != null)
                {
                    using (Stream stream = entry.Open())
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(stream);

                        bool hasChanges = false;

                        foreach (XmlNode node in doc.SelectNodes("root/experience/exp"))
                        {
                            string command = node.Attributes["cmd"].InnerText;
                            int first = Convert.ToInt32(node.Attributes["first"].InnerText);
                            int value = Convert.ToInt32(node.Attributes["value"].InnerText);

                            ExperienceSettingChange change = changes.FirstOrDefault(m => m.Name == command);
                            if (change != null && (change.First != first || change.Value != value))
                            {
                                log.Report($"Schreibe {change.Name}..");

                                if (change.First != first)
                                {
                                    hasChanges = true;

                                    node.Attributes["first"].InnerText = change.First.ToString();
                                    AppendPatchChange(patchInfo, "ExperienceSettings", command, "first", change.First.ToString());
                                }
                                if (change.Value != value)
                                {
                                    hasChanges = true;

                                    node.Attributes["first"].InnerText = change.Value.ToString();
                                    AppendPatchChange(patchInfo, "ExperienceSettings", command, "value", change.Value.ToString());
                                }
                            }
                        }

                        if (hasChanges)
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            doc.Save(stream);
                            stream.SetLength(stream.Position);
                            stream.Flush();
                        }
                        else
                        {
                            log.Report("Keine Änderungen gefunden");
                        }
                    }
                }
                else
                {
                    log.Report($"Element {ArchiveEntries.ExperienceSettings} nicht gefunden");
                }

                return true;
            });
        }

        #endregion
    }
}