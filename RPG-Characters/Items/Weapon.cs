using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public class Weapon : Item
    {
        public WeaponTypes WeaponType { get; set; }
        public WeaponAttributes WeaponAttributes { get; set; } = new WeaponAttributes();
    }
}
