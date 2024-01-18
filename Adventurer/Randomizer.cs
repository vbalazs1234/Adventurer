using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer
{
    internal static class Randomizer
    {
        public static int RandomNum()
        {
            Random r = new Random();
            return r.Next(1,7);
        }
    }
}
