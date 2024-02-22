using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventurer.Sprites.Enemies;
using Adventurer.Sprites.Hero;

namespace Adventurer.Sprites
{
    internal class PositionEvents
    {
        public void fightTest(Player player, Enemy enemy)
        {
            if (player.Position == enemy.Position)
            {
                int Dice, Sphere;
                Random random = new Random();
                Dice = random.Next(1, 21);
                Sphere = random.Next(1, 21);
                if (Dice >= Sphere)
                {
                    enemy.GotHit(player, enemy, Dice);
                }
                else if (Sphere > Dice)
                {
                    player.GotHit(player, enemy, Sphere);
                }
            }
        }
        public bool showEnemyStats(Player player, Enemy enemy)
        {
            int distance = 72;
            int distanceY = (int)player.Position.Y - (int)enemy.Position.Y;
            int distanceX = (int)player.Position.X - (int)enemy.Position.X;
            switch (player.Texture.Name)
            {
                case "Hero/hero-up":
                    if(player.Position.Y -  enemy.Position.Y == distance && distanceX==0)
                    {
                        Sprites.Enemies.StatDrawer enemyStat= new Sprites.Enemies.StatDrawer(enemy.HP, enemy.DP, enemy.SP, enemy.level);
                        return true;
                    }
                    return false;
                case "Hero/hero-down":
                    if (enemy.Position.Y - player.Position.Y == distance && distanceX == 0)
                    {
                        Sprites.Enemies.StatDrawer enemyStat = new Sprites.Enemies.StatDrawer(enemy.HP, enemy.DP, enemy.SP, enemy.level);
                        return true;
                    }
                    return false;
                case "Hero/hero-left":
                    if (player.Position.X - enemy.Position.X == distance && distanceY == 0)
                    {
                        Sprites.Enemies.StatDrawer enemyStat = new Sprites.Enemies.StatDrawer(enemy.HP, enemy.DP, enemy.SP, enemy.level);
                        return true;
                    }
                    return false;
                case "Hero/hero-right":
                    if (enemy.Position.X - player.Position.X == distance && distanceY == 0)
                    {
                        Sprites.Enemies.StatDrawer enemyStat = new Sprites.Enemies.StatDrawer(enemy.HP, enemy.DP, enemy.SP, enemy.level);
                        return true;
                    }
                    return false;
                default:
                    return false;
                    
            }
        }
    }
}
