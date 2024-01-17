using Microsoft.Xna.Framework;
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

        private Texture2D torch;
        private Texture2D trap;
        private Texture2D wall;
        private Texture2D floor;
        private Texture2D filler;

        public Texture2D[,] starter_room = new Texture2D[10, 10];
        public Texture2D[,] objects = new Texture2D[10, 10];
        public Maps(Texture2D wall , Texture2D floor,Texture2D torch,Texture2D filler,Texture2D trap)
        {
            this.torch = torch;
            this.filler = filler;
            this.wall = wall;
            this.floor = floor;
            this.trap = trap;
            basicMapGen();
            fillWhitObjects();
            addTorches();
        }
        public void basicMapGen()
        {
            Doors doors = new Doors(); 
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 && j == 4 ) starter_room[i, j] = doors.doorTopLeft;
                    else if( i == 0 && j == 5) starter_room[i, j] = doors.doorTopRight;
                    else if (i == 9 && j == 4 ) starter_room[i, j] = doors.doorBottomLeft;
                    else if (i == 9 && j == 5) starter_room[i, j] = doors.doorBottomRight;
                    else if (i == 4 && j == 0 ) starter_room[i, j] = doors.doorRightRight;
                    else if(i == 5 && j == 0) starter_room[i, j] = doors.doorRightLeft;
                    else if (i == 4 && j == 9 ) starter_room[i, j] = doors.doorLeftLeft;
                    else if(i == 5 && j == 9) starter_room[i, j] = doors.doorLeftRight;
                    else if (i == 0 || j == 0 || i == 9 || j == 9) starter_room[i, j] = wall;
                    else starter_room[i, j] = floor;
                }
            }
        }
        public void fillWhitObjects()
        {
            int wallcount = 0;
            
            for (int i = 2; i < 8; i++)
            {
                for (int j = 2; j < 8; j++)
                {
                  if (wallcount < 6 && rand.Next(1, 6) == 1 && i!=5 && j!=5)
                  { 
                        starter_room[i, j] = wall;
                        wallcount++;
                  }
                }
            }
        }
        public void addTorches()
        {
            int trapcount = 0;
            for (int a = 0; a < 2; a++)
            {
                if (a == 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            objects[i, j] = filler;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (trapcount < 5 && rand.Next(1, 6) == 1 && objects[i + 1, j] != trap && objects[i - 1, j] != trap && objects[i, j + 1] != trap && objects[i, j - 1] != trap && objects[i + 1, j + 1] != trap && objects[i + 1, j - 1] != trap && objects[i - 1, j + 1] != trap && objects[i - 1, j - 1] != trap)
                            {
                                if (starter_room[i,j] != wall)
                                {
                                objects[i, j] = trap;
                                trapcount++;
                                }
                            }
                        }
                    }
                }
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
    }
}
