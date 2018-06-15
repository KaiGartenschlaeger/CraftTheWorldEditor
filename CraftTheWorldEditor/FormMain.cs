using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace CraftTheWorldEditor
{
    public partial class FormMain : Form
    {
        #region Fields

        private string m_path;
        private readonly List<ResourceItem> m_craftResourceItems = new List<ResourceItem>();
        private readonly List<ResourceItem> m_craftResourceItemsListViewSource = new List<ResourceItem>();
        private readonly GeneralSettings generalSettings = new GeneralSettings();

        #endregion

        #region Constructor

        public FormMain()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        #endregion

        #region Helper

        private Dictionary<string, string> ReadCraftLang(XmlDocument doc)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (XmlNode node in doc["locals"].ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    result.Add(node.Name.ToLower(), node.InnerText ?? string.Empty);
                }
            }

            return result;
        }

        private void ReadWorldSettings(ZipArchive archive)
        {
            XmlDocument doc = archive.ReadDocument("data/world.xml");

            generalSettings.WorldSettings = new List<WorldSetting>();
            foreach (XmlNode node in doc["root"].ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    string name = node.Attributes["name"].InnerText;
                    string value = node.Attributes["value"].InnerText;
                    generalSettings.WorldSettings.Add(new WorldSetting(name, value));
                }
            }
        }
        private void ReadCharLevels(ZipArchive archive)
        {
            ZipArchiveEntry entry = archive.GetEntry("data/char_levels.txt");
            if (entry != null)
            {
                using (StreamReader reader = new StreamReader(entry.Open()))
                {
                    generalSettings.CharLevels = reader.ReadToEnd();
                }
            }
        }
        private void ReadCraftResources(ZipArchive archive)
        {
            XmlDocument craftResourcesLangDoc = archive.ReadDocument("Lang/German/data/local/craft_resources.xml");
            XmlDocument doc = archive.ReadDocument("data/craft_resources.xml");

            var craftResourcesLang = ReadCraftLang(craftResourcesLangDoc);

            m_craftResourceItems.Clear();

            foreach (XmlNode node in doc["root"].ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element && node.Name.Equals("resource", StringComparison.OrdinalIgnoreCase))
                {
                    ResourceItem item = new ResourceItem();
                    item.Name = node.Attributes["name"].InnerText;

                    if (node.Attributes["desc"] != null)
                    {
                        item.Description = node.Attributes["desc"].InnerText.Replace("%", string.Empty).ToLower();
                        if (craftResourcesLang.ContainsKey(item.Description))
                        {
                            item.Description = craftResourcesLang[item.Description];
                        }
                    }

                    item.Title = node.Attributes["title"].InnerText.Replace("%", string.Empty).ToLower();
                    if (craftResourcesLang.ContainsKey(item.Title))
                    {
                        item.Title = craftResourcesLang[item.Title];
                    }

                    if (node.Attributes["shop_count"] != null)
                    {
                        item.ShopCount = Convert.ToInt32(node.Attributes["shop_count"].InnerText);
                    }
                    if (node.Attributes["shop_cost"] != null)
                    {
                        item.ShopCost = Convert.ToInt32(node.Attributes["shop_cost"].InnerText);
                    }

                    if (node.Attributes["build"] != null)
                    {
                        item.Build = node.Attributes["build"].InnerText;
                    }

                    if (node.Attributes["properties"] != null)
                    {
                        item.Properties = node.Attributes["properties"].InnerText;
                    }

                    item.Application = "Misc";
                    if (node.Attributes["application"] != null && !string.IsNullOrEmpty(node.Attributes["application"].InnerText))
                    {
                        item.Application = node.Attributes["application"].InnerText;
                    }

                    m_craftResourceItems.Add(item);
                }
            }
        }
        private void ReadExperiences(ZipArchive archive)
        {
            XmlDocument doc = archive.ReadDocument(ArchiveEntries.ExperienceSettings);

            generalSettings.ExperienceSettings = new List<ExperienceSetting>();
            foreach (XmlNode node in doc.SelectNodes("root/experience/exp"))
            {
                ExperienceSetting setting = new ExperienceSetting();
                setting.Command = node.Attributes["cmd"].InnerText;
                setting.First = Convert.ToInt32(node.Attributes["first"].InnerText);
                setting.Value = Convert.ToInt32(node.Attributes["value"].InnerText);

                generalSettings.ExperienceSettings.Add(setting);
            }
        }

        #endregion

        #region Control events

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open Package File";
                dialog.Filter = "Package Files|*.pak";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        using (ZipArchive archive = new ZipArchive(File.OpenRead(dialog.FileName), ZipArchiveMode.Read))
                        {
                            ReadCraftResources(archive);
                            ReadWorldSettings(archive);
                            ReadCharLevels(archive);
                            ReadExperiences(archive);

                            m_path = dialog.FileName;

                            m_craftResourceItemsListViewSource.AddRange(m_craftResourceItems);
                            lvwCraftResources.VirtualListSize = m_craftResourceItemsListViewSource.Count;

                            propertyGrid1.SelectedObject = generalSettings;
                            btnSave.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed!\n\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private List<WorldSettingChange> GetWorldSettings()
        {
            List<WorldSettingChange> result = new List<WorldSettingChange>();
            foreach (var setting in generalSettings.WorldSettings)
            {
                result.Add(new WorldSettingChange()
                {
                    Name = setting.Name,
                    Value = setting.Value
                });
            }

            return result;
        }
        private List<ResourceItemChange> GetCraftResources()
        {
            List<ResourceItemChange> result = new List<ResourceItemChange>();
            foreach (ResourceItem resourceItem in m_craftResourceItems)
            {
                result.Add(new ResourceItemChange()
                {
                    Name = resourceItem.Name,
                    Type = "shop_cost",
                    Value = resourceItem.ShopCost.ToString()
                });
                result.Add(new ResourceItemChange()
                {
                    Name = resourceItem.Name,
                    Type = "shop_count",
                    Value = resourceItem.ShopCount.ToString()
                });
                result.Add(new ResourceItemChange()
                {
                    Name = resourceItem.Name,
                    Type = "properties",
                    Value = resourceItem.Properties
                });
            }

            return result;
        }
        private List<ExperienceSettingChange> GetExperienceSettings()
        {
            List<ExperienceSettingChange> result = new List<ExperienceSettingChange>();
            foreach (var setting in generalSettings.ExperienceSettings)
            {
                result.Add(new ExperienceSettingChange()
                {
                    Name = setting.Command,
                    First = setting.First,
                    Value = setting.Value
                });
            }

            return result;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Package File";
                dialog.Filter = "Package Files|*.pak";
                dialog.FileName = m_path;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                this.Enabled = false;
                FormPatchLog log = new FormPatchLog();
                log.AllowClose = false;
                log.Location = new System.Drawing.Point(
                    this.Left + this.Width / 2 - log.Width / 2,
                    this.Top + this.Height / 2 - log.Height / 2);
                log.FormClosed += (a, b) => { this.Enabled = true; };
                log.Show(this);

                IProgress<string> progress = new Progress<string>((message) =>
                {
                    log.Add(message);
                });

                try
                {
                    // copy file to target path
                    if (dialog.FileName != m_path)
                    {
                        progress.Report("Kopiere Datei..");
                        await FileHelper.CopyAsync(m_path, dialog.FileName, true);
                    }

                    string patchPath = Path.Combine(
                        Path.GetDirectoryName(dialog.FileName),
                        Path.GetFileNameWithoutExtension(dialog.FileName) + ".patch.xml");

                    // create patch info file
                    XmlDocument patchInfo = new XmlDocument();
                    if (File.Exists(patchPath))
                    {
                        patchInfo.Load(patchPath);
                    }
                    else
                    {
                        XmlNode rootNode = patchInfo.CreateNode(XmlNodeType.Element, "patch", null);
                        patchInfo.AppendChild(rootNode);
                    }

                    using (Stream stream = File.Open(dialog.FileName, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Update))
                        {
                            await Patcher.PatchWorldSettings(archive, GetWorldSettings(), progress, patchInfo);
                            await Patcher.PatchCraftResources(archive, GetCraftResources(), progress, patchInfo);
                            await Patcher.PatchCharLevels(archive, generalSettings.CharLevels, progress, patchInfo);
                            await Patcher.PatchExperienceSettings(archive, GetExperienceSettings(), progress, patchInfo);
                        }
                    }

                    patchInfo.Save(patchPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    log.AllowClose = true;
                }
            }
        }

        private void btnApplyPatch_Click(object sender, EventArgs e)
        {
            using (FormApplyPatch dialog = new FormApplyPatch())
            {
                dialog.ShowDialog(this);
            }
        }

        private void lvwCraftResources_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = m_craftResourceItemsListViewSource[e.ItemIndex];
            lvi.Text = m_craftResourceItemsListViewSource[e.ItemIndex].Title;
            lvi.SubItems.Add(m_craftResourceItemsListViewSource[e.ItemIndex].Application);
            lvi.SubItems.Add(m_craftResourceItemsListViewSource[e.ItemIndex].ShopCount.ToString());
            lvi.SubItems.Add(m_craftResourceItemsListViewSource[e.ItemIndex].ShopCost.ToString());
            lvi.SubItems.Add(m_craftResourceItemsListViewSource[e.ItemIndex].Properties ?? string.Empty);

            e.Item = lvi;
        }
        private void lvwCraftResources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lvwCraftResources.SelectedIndices.Count > 0)
            {
                ResourceItem selectedItem = m_craftResourceItemsListViewSource[lvwCraftResources.SelectedIndices[0]];
                using (FormCraftResource dialog = new FormCraftResource(selectedItem))
                {
                    dialog.ShowDialog(this);
                    lvwCraftResources.Refresh();
                }
            }
        }

        private void tbxItemSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxItemSearch.Text))
            {
                m_craftResourceItemsListViewSource.Clear();
                m_craftResourceItemsListViewSource.AddRange(m_craftResourceItems.Where(i =>
                {
                    if (i.Title.IndexOf(tbxItemSearch.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        return true;
                    }
                    else if (i.Properties != null && i.Properties.IndexOf(tbxItemSearch.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        return true;
                    }
                    else if (i.Application.IndexOf(tbxItemSearch.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        return true;
                    }

                    return false;
                }));
            }
            else
            {
                m_craftResourceItemsListViewSource.Clear();
                m_craftResourceItemsListViewSource.AddRange(m_craftResourceItems);
            }

            lvwCraftResources.VirtualListSize = m_craftResourceItemsListViewSource.Count;
            lvwCraftResources.Refresh();
        }

        #endregion
    }
}
