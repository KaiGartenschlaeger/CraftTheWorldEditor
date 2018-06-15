using CraftTheWorldEditor.PropGridEditors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CraftTheWorldEditor
{
    class GeneralSettings
    {
        [DisplayName("Level")]
        [Editor(typeof(MultilineTextUITypeEditor), typeof(UITypeEditor))]
        public string CharLevels { get; set; }

        [DisplayName("Welt Einstellungen")]
        [Editor(typeof(CollectionUITypeEditor<WorldSetting>), typeof(UITypeEditor))]
        public List<WorldSetting> WorldSettings { get; set; }

        [DisplayName("Erfahrungspunkte")]
        [Editor(typeof(CollectionUITypeEditor<ExperienceSetting>), typeof(UITypeEditor))]
        public List<ExperienceSetting> ExperienceSettings { get; set; }
    }
}