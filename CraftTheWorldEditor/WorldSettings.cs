using System.ComponentModel;

namespace CraftTheWorldEditor
{
    class WorldSetting
    {
        public WorldSetting(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [DisplayName("Name")]
        [ReadOnly(true)]
        public string Name { get; set; }

        [DisplayName("Wert")]
        public string Value { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}