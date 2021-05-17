using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public class InvalidWeaponException : Exception
    {

        public InvalidWeaponException()
        {
            //return ($"CAN NOT EQUIP {weapon.ItemName}");
        }

    }

}