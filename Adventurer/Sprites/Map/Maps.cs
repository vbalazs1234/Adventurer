using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Adventurer.Sprites.Map
{
    internal class Maps
    {
        Random rand = new Random();

        public static Texture2D torch;
        public static Texture2D wall;
        public static Texture2D floor;
        public static Texture2D filler;
        public static int keyRoomPozition_X;
        public static int keyRoomPozition_Y;
        public static int keyInsideRoomPozition_X;
        public static int keyInsideRoomPozition_Y;

        public Texture2D[,] starter_room = new Texture2D[10, 10];
        public Texture2D[,] objects = new Texture2D[10, 10];
        int[,] Blocks = new int[4, 4];
        public Maps(int aPozition, int bPozition)
        { 
            if (torch != null)
            {
                basicMapGen(aPozition,bPozition);
                RandomWalls();
                addObjects(aPozition, bPozition);
            }
        }
        public void LoadContent(ContentManager Content)
        {
            floor = Content.Load<Texture2D>("Maps/floor");
            wall = Content.Load<Texture2D>("Maps/wall");
            torch = Content.Load<Texture2D>("Maps/torch");
            filler = Content.Load<Texture2D>("Maps/filler");;
        }
        public void basicMapGen(int aPozition,int bPozition)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 && j == 4 && aPozition != 0) starter_room[i, j] = Doors.doorTopLeft;
                    else if (i == 0 && j == 5 && aPozition != 0) starter_room[i, j] = Doors.doorTopRight;
                    else if (i == 9 && j == 4 && aPozition != 4) starter_room[i, j] = Doors.doorBottomLeft;
                    else if (i == 9 && j == 5 && aPozition != 4) starter_room[i, j] = Doors.doorBottomRight;
                    else if (i == 4 && j == 0 && bPozition != 0) starter_room[i, j] = Doors.doorLeftRight;
                    else if (i == 5 && j == 0 && bPozition != 0) starter_room[i, j] = Doors.doorLeftLeft;
                    else if (i == 4 && j == 9 && bPozition != 4) starter_room[i, j] = Doors.doorRightLeft;
                    else if (i == 5 && j == 9 && bPozition != 4) starter_room[i, j] = Doors.doorRightRight;
                    else if (i == 4 && j == 9 && bPozition == 4 && aPozition == 2) starter_room[i, j] = Doors.bossRoomLeftClosed;
                    else if (i == 5 && j == 9 && bPozition == 4 && aPozition == 2) starter_room[i, j] = Doors.bossRoomRightClosed;
                    else if (i == 0 || j == 0 || i == 9 || j == 9) starter_room[i, j] = wall;
                    else starter_room[i, j] = floor;
                }
            }
        }
        public void RandomWalls()
        {
            int wallcount = 0;
            sections();
            for (int a = 0; a < 4; a++)
            {
                for (int i = Blocks[a,0]; i < Blocks[a,1]; i++)
                {
                    for (int j = Blocks[a,2]; j < Blocks[a,3]; j++)
                    {
                        if (wallcount < 3 && rand.Next(1, 6) == 1 )
                        {
                            if (i == 5 && j == 5) starter_room[i, j] = floor; 
                            else
                            {
                            starter_room[i, j] = wall;
                            wallcount++;
                            }
                        }
                    }
                }    
                wallcount = 0;
            }
        }
        public void addObjects(int aPozition, int bPozition)
        {
            int chestcount = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    objects[i, j] = filler;
                }
            }
            for (int a = 0; a < 4; a++)
            {
                for (int i = Blocks[a,0]; i < Blocks[a, 1]; i++)
                {
                    for (int j = Blocks[a, 2]; j < Blocks[a, 3]; j++)
                    {
                        if (chestcount < 1 && rand.Next(1, 101) == 1)
                        {
                            if (starter_room[i, j] != wall)
                            {
                                objects[i, j] = Objects.chest;
                                chestcount++;
                            }
                        }
                    }
                }   
            }
            if (aPozition == keyRoomPozition_Y && bPozition == keyRoomPozition_X)
            {
                bool keyExists=true;
                do
                {
                    keyInsideRoomPozition_X = rand.Next(1, 9);
                    keyInsideRoomPozition_Y = rand.Next(1, 9);
                    if (starter_room[keyInsideRoomPozition_Y, keyInsideRoomPozition_X].Name == "Maps/floor")
                    {
                        objects[keyInsideRoomPozition_Y, keyInsideRoomPozition_X] = Doors.bossRoomDoorKey;
                        keyExists = false;
                    }
                } while (keyExists);
                
            }
            objects[1, 0] = torch;
            objects[1, 9] = torch;
            objects[8, 0] = torch;
            objects[8, 9] = torch;
            objects[0, 1] = torch;
            objects[9, 1] = torch;
            objects[0, 8] = torch;
            objects[9, 8] = torch;


        }
        private void sections()
        {
            int[] firstblock = new int[] { 2, 5, 2, 5 };
            int[] secondblock = new int[] { 5, 8, 2, 5 };
            int[] thirdblock = new int[] { 2, 5, 5, 8 };
            int[] fourthblock = new int[] { 5, 8, 5, 8 };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0)
                    {
                        Blocks[i, j] = firstblock[j];
                    }
                    if (i == 1)
                    {
                        Blocks[i, j] = secondblock[j];
                    }
                    if (i == 2)
                    {
                        Blocks[i, j] = thirdblock[j];
                    }
                    if (i == 3)
                    {
                        Blocks[i, j] = fourthblock[j];
                    }
                }
            }
        }
    }
}
