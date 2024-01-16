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

namespace Adventurer.Sprites.Map
{
    internal class Maps 
    {
        Texture2D[,] map = new Texture2D[10, 10];
        public Texture2D[,] starter_room = new Texture2D[10, 10];
        public Maps(Texture2D door,Texture2D wall , Texture2D floor)
        {
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 && j == 4 || i == 0 && j == 5) starter_room[i, j] = door;
                    else if (i == 9 && j == 4 || i == 9 && j == 5) starter_room[i, j] = door;
                    else if (i == 4 && j == 0 || i == 5 && j == 0) starter_room[i, j] = door;
                    else if (i == 4 && j == 9 || i == 5 && j == 9) starter_room[i, j] = door;
                    else if (i == 0 || j == 0 || i == 9 || j == 9) starter_room[i, j] = wall;
                    else starter_room[i, j] = floor;
                }
            }
        }
    }
}
