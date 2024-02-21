using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Adventurer.Sprites.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Adventurer.Sprites
{
    internal class Sprite
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Origin { get; set; }

        private float Scale = 1f;

        public enum EnemyState
        {
            Moving,
            Waiting
        }

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
            Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
        }

       
        
        
        public virtual void Update(GameTime gameTime, GraphicsDeviceManager _graphics, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, float scale)
        {
            Scale = scale;
            spriteBatch.Draw(Texture, rectangle, Color.White);
        }
    }
}
