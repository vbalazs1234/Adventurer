using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer
{
    internal class Randomizer
    {
        protected int RandomNum()
        {
            Random r = new Random();
            return r.Next(1,7);
        }
    }
}
