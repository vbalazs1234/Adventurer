using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Adventurer.Sprites.Map
{
    internal class Objects
    {
        public static Texture2D chest;
        public Objects()
        {
            
        }
        public void LoadContent(ContentManager Content)
        {
            chest = Content.Load<Texture2D>("Maps/Objects/chest");
        }
    }
}
