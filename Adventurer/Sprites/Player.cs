using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Adventurer.Sprites
{
    internal class Player : Sprite
    {
        public float Speed = 2f;
        public bool canMove = true;
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.W) && canMove != false)
            {
                Position.Y -= Speed;
                canMove = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && canMove != false)
            {
                Position.Y += Speed;
                canMove = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && canMove != false)
            {
                Position.X -= Speed;
                canMove = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && canMove != false)
            {
                Position.X += Speed;
                canMove = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D) && canMove == false)
            {
                canMove = true;
            }
        }
    }
}
