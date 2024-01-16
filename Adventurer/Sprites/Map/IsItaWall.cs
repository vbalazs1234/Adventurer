using System;
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
        
        public bool Is_it_a_wall_upward(Vector2 Position)
        {
            for (int i = 0; i < spriteses.Count; i++)
            {
                if (Position.Y-spriteses[i].Texture.Height == spriteses[i].Position.Y && Position.X == spriteses[i].Position.X)
                {
                    if (spriteses[i].Texture.Name == "Maps/wall")
                    {
                    return true;
                    }
                }
            }
            return false;
        }
        public bool Is_it_a_wall_downward(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.Y + item.Texture.Height == item.Position.Y && Position.X == item.Position.X)
                {
                    if (item.Texture.Name == "Maps/wall")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Is_it_a_wall_left(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.X - item.Texture.Height == item.Position.X && Position.Y == item.Position.Y)
                {
                    if (item.Texture.Name == "Maps/wall")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Is_it_a_wall_right(Vector2 Position)
        {
            foreach (var item in spriteses)
            {
                if (Position.X + item.Texture.Height == item.Position.X && Position.Y == item.Position.Y)
                {
                    if (item.Texture.Name == "Maps/wall")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
