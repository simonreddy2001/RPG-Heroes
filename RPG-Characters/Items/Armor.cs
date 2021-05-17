using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public class Armor : Item
    {
        public ArmorTypes ArmorType { get; set; }
        public PrimaryAttributes Attributes { get; set; } = new PrimaryAttributes();
    }
}
