using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites.Map
{
    internal class MapsInOne
    {
        public Maps[,] maps;
        public static int PlayerMapPosition_X = 2;
        public static int PlayerMapPosition_Y = 2;
        public static int PreviousPlayerMapPosition_X = 2;
        public static int PreviousPlayerMapPosition_Y = 2;
        public MapsInOne()
        {
            maps = new Maps[5,5];
        }
        public void fill()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Maps map = new Maps(i,j);
                    maps[i, j] = map;
                }
            }
        }
    }
}
