using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites.Item
{
    internal class HealingOrb : Items
    {
        public HealingOrb() 
        {
            Name = "Healing Orb";
            Description = "Heals the user.";
            Durability = 1;
            Damage = 0;
        }
        public override  int useItem(int MaxHp,int ActualHp)
        {
            if(MaxHp-ActualHp>=10) ActualHp += 10;
            else ActualHp =MaxHp;
            damageItem();
            Console.WriteLine(Durability);
            return ActualHp;
        }
    }
}
