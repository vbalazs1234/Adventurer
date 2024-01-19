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
        public static bool isOpened = false;
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
        public void chanegeDoor()
        {
            if (PlayerMapPosition_X == 4 && PlayerMapPosition_Y == 2)
            {
                

                if (isOpened)
                {
                    maps[2,4].starter_room[4, 9] = Doors.bossRoomLeftOpened;
                    maps[2,4].starter_room[5, 9] = Doors.bossRoomRightOpened;
                }
                else
                {
                    maps[2,4].starter_room[4, 9] = Doors.bossRoomLeftClosed;
                    maps[2,4].starter_room[5, 9] = Doors.bossRoomRightClosed;
                }
            }
        }
    }
}
