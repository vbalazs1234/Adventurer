using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites.Item
{
    internal class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public int Damage { get; set; }
        public string showText;

        public virtual void useItem() { }
        public virtual void damageItem() { Durability--; }
    }
}
