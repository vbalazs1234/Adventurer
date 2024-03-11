using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites.Enemies.Boss
{
    internal class Boss : Enemy
    {
        public Boss(Texture2D texture, Vector2 position, int level) : base(texture, position,level)
        {

        }
        public override void Update(GameTime gameTime, GraphicsDeviceManager graphics, List<Sprite> sprites)
        {
            base.Update(gameTime, graphics, sprites);
        }
    }
}
