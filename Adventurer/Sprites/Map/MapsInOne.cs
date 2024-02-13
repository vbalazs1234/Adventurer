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
        public Maps bossroom;
        public static int PlayerMapPosition_X = 2;
        public static int PlayerMapPosition_Y = 2;
        public static int PreviousPlayerMapPosition_X = 2;
        public static int PreviousPlayerMapPosition_Y = 2;
        public static bool isOpened = false;
        public static bool keyChange = false;
        public static bool objectChange = false;
        public static bool nextLevel=false;

        private Random rand = new Random(); 
        public MapsInOne()
        {
            maps = new Maps[5,5];
            bossroom = new Maps();
        }
        public void fill()
        {
            Maps.keyRoomPozition_X = rand.Next(0, 5);
            Maps.keyRoomPozition_Y = rand.Next(0, 5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Maps map = new Maps(i,j);
                    maps[i, j] = map;
                }
            }
            bossroom.bossRoomGen();
            bossroom.addObjects();
        }
        public void removeObject()
        {
            maps[PlayerMapPosition_Y, PlayerMapPosition_X].objects[Player.P_Position_Y,Player.P_Position_X] = Maps.filler;
            objectChange= false;
        }
        public void chanegeDoor()
        {
            if(keyChange)
            {
                maps[Maps.keyRoomPozition_Y,Maps.keyRoomPozition_X].objects[Maps.keyInsideRoomPozition_Y, Maps.keyInsideRoomPozition_X] = Maps.filler;
            }
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
