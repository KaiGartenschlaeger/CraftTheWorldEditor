using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Xml;

namespace CraftTheWorldEditor
{
    internal class PatchProcess
    {
        #region Fields

        private string m_patchFilePath;
        private string m_dataFilePath;

        #endregion

        #region Constructor

        public PatchProcess(string patchFilePath, string dataFilePath)
        {
            m_patchFilePath = patchFilePath;
            m_dataFilePath = dataFilePath;
        }

        #endregion

        #region Helper

        private XmlDocument ReadPatchFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(File.ReadAllText(m_patchFilePath));

            return doc;
        }

        private List<ResourceItemChange> ReadCraftResources(IProgress<string> progress, XmlDocument doc)
        {
            List<ResourceItemChange> result = new List<ResourceItemChange>();

            progress.Report("Lese Gegenstände..");

            foreach (XmlNode node in doc.SelectNodes("patch/CraftResources/change"))
            {
                ResourceItemChange change = new ResourceItemChange();
                change.Name = node.Attributes["name"].InnerText;
                change.Type = node.Attributes["type"].InnerText;
                change.Value = node.Attributes["to"].InnerText;
                result.Add(change);
            }

            return result;
        }

        private void PatchCraftResources(ZipArchive archive, IProgress<string> progress, List<ResourceItemChange> changes)
        {

        }

        private List<WorldSettingChange> ReadWorldSettings(IProgress<string> progress, XmlDocument doc)
        {
            List<WorldSettingChange> result = new List<WorldSettingChange>();

            progress.Report("Lese Welt Einstellungen..");

            foreach (XmlNode node in doc.SelectNodes("patch/WorldSettings/change"))
            {
                WorldSettingChange change = new WorldSettingChange();
                change.Name = node.Attributes["name"].InnerText;
                //change.Type = node.Attributes["type"].InnerText;
                change.Value = node.Attributes["to"].InnerText;
                result.Add(change);
            }

            return result;
        }

        private void PatchWorldSettings(ZipArchive archive, IProgress<string> progress, List<WorldSettingChange> changes)
        {

        }

        //private List<ExperienceSettingChange> ReadExperienceSettings(IProgress<string> progress, XmlDocument doc)
        //{
        //    List<ExperienceSettingChange> result = new List<ExperienceSettingChange>();

        //    progress.Report("Lese Erfahrungspunkte..");

        //    foreach (XmlNode node in doc.SelectNodes("patch/ExperienceSettings/change"))
        //    {
        //        ExperienceSettingChange change = new ExperienceSettingChange();
        //        change.Name = node.Attributes["name"].InnerText;
        //        change.Type = node.Attributes["type"].InnerText;
        //        change.Value = Convert.ToInt32(node.Attributes["to"].InnerText);
        //        result.Add(change);
        //    }

        //    return result;
        //}

        private void PatchExperienceSettings(ZipArchive archive, IProgress<string> progress, List<ExperienceSettingChange> changes)
        {

        }

        private string ReadCharLevels(IProgress<string> progress, XmlDocument doc)
        {
            string result = string.Empty;

            progress.Report("Lese Level..");

            XmlNode node = doc.SelectSingleNode("patch/CharLevels/change");
            if (node != null)
            {
                XmlCDataSection dataSection = node.ChildNodes[0] as XmlCDataSection;
                if (dataSection != null)
                {
                    result = dataSection.InnerText;
                }
            }

            return result;
        }

        private void PatchCharLevels(ZipArchive archive, IProgress<string> progress, string change)
        {
            progress.Report("Patche Level..");

            var entry = archive.GetEntry(ArchiveEntries.CharLevels);
            if (entry != null)
            {
                string content = entry.ReadString();
                if (content != change)
                {
                    entry.SetString(change);
                    progress.Report("Level Patch OK");
                }
            }
            else
            {
                progress.Report($"Fehler: {ArchiveEntries.CharLevels} nicht gefunden!");
            }
        }

        #endregion

        #region Methods

        public Task<bool> PatchAsync(IProgress<string> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    XmlDocument patches = new XmlDocument();
                    using (Stream stream = File.OpenRead(m_patchFilePath))
                    {
                        patches.Load(stream);
                    }

                    progress.Report("Öffne Patch-Datei..");

                    if (patches["patch"] == null)
                    {
                        progress.Report("Fehler: Ungültige Patch-Datei");
                        return false;
                    }

                    var craftResources = ReadCraftResources(progress, patches);
                    var charLevels = ReadCharLevels(progress, patches);
                    var worldSettings = ReadWorldSettings(progress, patches);
                    //var experienceSettings = ReadExperienceSettings(progress, patches);

                    progress.Report("Öffne Daten-Datei..");
                    using (ZipArchive archive = ZipFile.Open(m_dataFilePath, ZipArchiveMode.Update))
                    {
                        progress.Report("Patche Gegenstände..");
                        PatchCraftResources(archive, progress, craftResources);
                        PatchCharLevels(archive, progress, charLevels);

                        progress.Report("Patche Welt Einstellungen..");
                        PatchWorldSettings(archive, progress, worldSettings);

                        progress.Report("Patche Erfahrungspunkte..");
                        //PatchExperienceSettings(archive, progress, experienceSettings);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    progress.Report("Fehler: " + ex.Message);
                    return false;
                }
            });
        }

        #endregion
    }
}