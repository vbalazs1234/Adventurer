using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites
{
    internal class PositionEvents
    {
        public void fightTest(Player player,Enemy enemy)
        {
            if (player.Position == enemy.Position)
            {
                int Dice,Sphere;
                Random random = new Random();
                Dice = random.Next(1, 21);
                Sphere = random.Next(1, 21);
                if (Dice>=Sphere)
                {
                    enemy.GotHit( player, enemy);
                }
                else if (Sphere > Dice)
                {
                   player.GotHit(player, enemy);
                }
            }
        }
    }
}
