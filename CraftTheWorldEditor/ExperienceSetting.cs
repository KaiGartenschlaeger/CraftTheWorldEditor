using System.ComponentModel;

namespace CraftTheWorldEditor
{
    public class ExperienceSetting
    {
        [DisplayName("Bedeutung")]
        [ReadOnly(true)]
        public string Command { get; set; }

        [DisplayName("Wert (erstes mal)")]
        public int First { get; set; }

        [DisplayName("Wert (erneut)")]
        public int Value { get; set; }


        public override string ToString()
        {
            return Command;
        }
    }
}