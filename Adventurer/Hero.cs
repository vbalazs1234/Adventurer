using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer
{
    internal class Hero :Randomizer
    {
        protected int MaxHp;
        protected int ActualHp;
        protected int DefensePoint;
        protected int Damage;


        public Hero()
        {
            MaxHp = 20 + 3 * RandomNum();
            MaxHp = ActualHp;
            DefensePoint = 2 * RandomNum();
            Damage = 5 + RandomNum();
        }

        protected void LevelUp()
        {
            MaxHp = MaxHp += RandomNum();
            DefensePoint += RandomNum();
            Damage += RandomNum();

        }
    }
}
