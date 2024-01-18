﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Adventurer.Sprites.Map
{
    internal class Doors
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Texture2D doorTopLeft;
        public static Texture2D doorTopRight;
        public static Texture2D doorBottomLeft;
        public static Texture2D doorBottomRight;
        public static Texture2D doorLeftLeft;
        public static Texture2D doorLeftRight;
        public static Texture2D doorRightLeft;
        public static Texture2D doorRightRight;
        public Doors()
        {
        }
        public void LoadContent(ContentManager Content)
        { 
            doorBottomLeft = Content.Load<Texture2D>("Maps/Doors/doorBottomLeft");
            doorBottomRight = Content.Load<Texture2D>("Maps/Doors/doorBottomRight");
            doorTopLeft = Content.Load<Texture2D>("Maps/Doors/doorTopLeft");
            doorTopRight  = Content.Load<Texture2D>("Maps/Doors/doorTopRight");
            doorLeftLeft = Content.Load<Texture2D>("Maps/Doors/doorLeftLeft");
            doorLeftRight = Content.Load<Texture2D>("Maps/Doors/doorLeftRight");
            doorRightLeft = Content.Load<Texture2D>("Maps/Doors/doorRightLeft");
            doorRightRight = Content.Load<Texture2D>("Maps/Doors/doorRightRight");
        }
    }
}
