﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Adventurer.Sprites
{
    internal class Sprite
    {
        public Texture2D Texture;
        public Vector2 Position;

        private float Scale = 1f;

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width * (int)Scale, Texture.Height * (int)Scale);
            }
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            Position = position;
            Texture = texture;
        }



        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rectangle, Color.White);
        }
    }
}