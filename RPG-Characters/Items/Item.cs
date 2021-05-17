using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public abstract class Item
    {
        public string ItemName { get; set; }
        public int ItemLevel { get; set; }
        public Slots ItemSlot { get; set; }
    }
}
