using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {
        //return ($"CAN Not EQUIP {armor.ItemName}");
        }
        
    }
}
