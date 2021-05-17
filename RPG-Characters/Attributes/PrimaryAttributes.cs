using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public class PrimaryAttributes
    {
        public int Strength { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Intelligence { get; set; } = 0;
        public int Vitality { get; set; } = 0;

        public static PrimaryAttributes operator + (PrimaryAttributes a, PrimaryAttributes b)
        {
            PrimaryAttributes primaryAttributes = new PrimaryAttributes
            {
                Strength = a.Strength + b.Strength,
                Dexterity = a.Dexterity + b.Dexterity,
                Intelligence = a.Intelligence + b.Intelligence,
                Vitality = a.Vitality + b.Vitality
            };
            return primaryAttributes;
        }
    }
}
