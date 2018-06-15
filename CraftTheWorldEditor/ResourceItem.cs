using System.ComponentModel;

namespace CraftTheWorldEditor
{
    public class ResourceItem
    {
        [ReadOnly(true)]
        [DisplayName("Titel")]
        public string Title { get; set; }

        [ReadOnly(true)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [ReadOnly(true)]
        [DisplayName("Beschreibung")]
        public string Description { get; set; }

        [ReadOnly(true)]
        [DisplayName("Build")]
        public string Build { get; set; }

        [DisplayName("Shop Anzahl")]
        public int ShopCount { get; set; }

        [DisplayName("Shop Preis")]
        public int ShopCost { get; set; }

        [DisplayName("Eigenschaften")]
        public string Properties { get; set; }

        [ReadOnly(true)]
        [DisplayName("Gruppe")]
        public string Application { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}