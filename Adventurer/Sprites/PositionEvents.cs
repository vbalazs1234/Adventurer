using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites
{
    internal class PositionEvents
    {
        public Player fightTest(Player player,Enemy enemy)
        {
            
                if (player.Position == enemy.Position)
                {
                    player.collectExp((enemy.level*10)+30);
                }
            
            return player;
        }
    }
}
