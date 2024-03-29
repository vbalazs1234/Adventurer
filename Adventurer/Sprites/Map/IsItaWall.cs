﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventurer.Sprites.Map
{
    internal class IsItaWall
    {
        public static List<Sprite> spriteses;
        public static int enemyCount=0;
        public int Is_it_a_wall_upward(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.Y - item.Texture.Height == item.Position.Y && Position.X == item.Position.X)
                {
                    if (item.Texture.Name == "Maps/Doors/doorTopLeft" || item.Texture.Name == "Maps/Doors/doorTopRight")
                    {
                        if (enemyCount == 0)
                        {
                            return 2;
                        }
                        return 1;
                    }
                    if (Checkingzone(item) != 0)
                    {
                        return Checkingzone(item);
                    }
                }
            }
            return 0;
        }
        public int Is_it_a_wall_downward(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.Y + item.Texture.Height == item.Position.Y && Position.X == item.Position.X)
                {
                    if (item.Texture.Name == "Maps/Doors/doorBottomLeft" || item.Texture.Name == "Maps/Doors/doorBottomRight")
                    {
                        if (enemyCount == 0)
                        {
                            return 2;
                        }
                        return 1;
                    }
                    if (Checkingzone(item) != 0)
                    {
                        return Checkingzone(item);
                    }
                }
            }
            return 0;
        }
        public int Is_it_a_wall_left(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.X - item.Texture.Height == item.Position.X && Position.Y == item.Position.Y)
                {
                    if (item.Texture.Name == "Maps/Doors/doorLeftLeft" || item.Texture.Name == "Maps/Doors/doorLeftRight")
                    {
                        if (enemyCount == 0)
                        {
                            return 2;
                        }
                        return 1;
                    }
                    if (Checkingzone(item) != 0)
                    {
                        return Checkingzone(item);
                    }
                }
            }
            return 0;
        }
        public int Is_it_a_wall_right(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.X + item.Texture.Height == item.Position.X && Position.Y == item.Position.Y)
                {
                    if (item.Texture.Name == "Maps/Doors/doorRightLeft" || item.Texture.Name == "Maps/Doors/doorRightRight")
                    {
                        if (enemyCount == 0)
                        {
                            return 2;
                        }
                        return 1;
                    }
                    else if (item.Texture.Name == "Maps/Doors/BossRoom/boss-room-door-left" || item.Texture.Name == "Maps/Doors/BossRoom/boss-room-door-right")
                    {
                        if (enemyCount == 0)
                        {
                            return 5;
                        }
                        return 1;
                    }
                    else if (item.Texture.Name == "Maps/Doors/BossRoom/boss-room-door-left-closed" || item.Texture.Name == "Maps/Doors/BossRoom/boss-room-door-right-closed")
                    {
                        return 1;
                    }
                    if(Checkingzone(item) !=0)
                    {
                        return Checkingzone(item);
                    }
                }
            }
            return 0;
        }
        private int Checkingzone(Sprite item)
        {
            if (item.Texture.Name == "Maps/wall")
            {
                return 1;
            }
            else if (item.Texture.Name == "Maps/key")
            {
                return 3;
            }
            else if (item.Texture.Name == "Maps/Objects/chest")
            {
                return 4;
            }
            else if(item.Texture.Name == "Maps/Objects/ladder")
            {
                MapsInOne.nextLevel = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
