using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adventurer;
using System.Threading.Tasks;
using Adventurer.Sprites.Map;
using Adventurer.Sprites.Item;
using System.Diagnostics;

namespace Adventurer.Sprites
{
    internal class Enemy : Sprite
    {
        private IsItaWall isItaWall = new IsItaWall();
        public static string enemy_image_name = "Hero/hero-down";
        private Texture2D enemy_image;
        private Random rnd;
        public static bool canMove;
        public int level;
        private int HP, SP;
        private float DP;

        public Enemy(Texture2D texture, Vector2 position,int level) : base(texture, position)
        {
            enemy_image = texture;
            rnd = new Random();
            canMove = false;
            int levelChance=rnd.Next(1, 101);
            if (levelChance <= 50) this.level = level;
            else if (levelChance > 50 && levelChance <= 90) this.level = level++;
            else this.level = level + 2;
            HP = 2 * this.level * rnd.Next(1, 7);
            DP= (float)this.level /2 * rnd.Next(1, 7);
            SP = this.level * rnd.Next(1, 7);
        }

        public override void Update(GameTime gameTime, GraphicsDeviceManager graphics, List<Sprite> sprites)
        {
            int[] pos = new int[2];
            pos[0] = (int)Position.X;
            pos[1] = (int)Position.Y;




            //movement clockwise
            if (canMove == true)
            {
            int random = rnd.Next(1, 5);
            Debug.WriteLine($"{random}");
                switch (random)
                {
                    case 1:
                        switch (isItaWall.Is_it_a_wall_upward(Position))
                        {
                            case 1:
                                enemy_image_name = "Hero/hero-up";
                                break;
                            case 2:
                                enemy_image_name = "Hero/hero-up";
                                canMove = false;
                                break;
                            case 3:
                                Position.Y -= enemy_image.Height;
                                enemy_image_name = "Hero/hero-up";
                                canMove = false;
                                break;
                            case 4:

                                Position.Y -= enemy_image.Height;
                                enemy_image_name = "Hero/hero-up";
                                canMove = false;
                                break;
                            default:
                                Position.Y -= enemy_image.Height;
                                enemy_image_name = "Hero/hero-up";
                                canMove = false;
                                break;
                        }
                
                    break;
                    case 3:
                        switch (isItaWall.Is_it_a_wall_downward(Position))
                        {
                            case 1:
                                enemy_image_name = "Hero/hero-down";
                                break;
                            case 2:
                                enemy_image_name = "Hero/hero-down";
                                break;
                            case 3:
                                Position.Y += enemy_image.Height;
                                enemy_image_name = "Hero/hero-down";
                           
                                break;
                            case 4:

                                Position.Y += enemy_image.Height;
                                enemy_image_name = "Hero/hero-down";
                             
                                break;
                            default:
                                Position.Y += enemy_image.Height;
                                enemy_image_name = "Hero/hero-down";
                                
                                break;
                        }
                        break;
                    case 4: // Moving left
                        switch (isItaWall.Is_it_a_wall_left(Position))
                        {
                            case 1:
                                enemy_image_name = "Hero/hero-left";
                                break;
                            case 2:
                                enemy_image_name = "Hero/hero-left";
                                canMove = false;
                                break;
                            case 3:
                                Position.X -= enemy_image.Width;
                                enemy_image_name = "Hero/hero-left";
                                canMove = false;
                                break;
                            case 4:
                                Position.X -= enemy_image.Width;
                                enemy_image_name = "Hero/hero-left";
                                canMove = false;
                                break;
                            default:
                                Position.X -= enemy_image.Width;
                                enemy_image_name = "Hero/hero-left";
                                canMove = false;
                                break;
                        }
                        break;
                    case 2: // Moving right
                        switch (isItaWall.Is_it_a_wall_right(Position))
                        {
                            case 1:
                                enemy_image_name = "Hero/hero-right";
                                break;
                            case 2:
                                enemy_image_name = "Hero/hero-right";
                                canMove = false;
                                break;
                            case 3:
                                Position.X += enemy_image.Width;
                                enemy_image_name = "Hero/hero-right";
                                canMove = false;
                                break;
                            case 4:
                                Position.X += enemy_image.Width;
                                enemy_image_name = "Hero/hero-right";
                                canMove = false;
                                break;
                            default:
                                Position.X += enemy_image.Width;
                                enemy_image_name = "Hero/hero-right";
                                canMove = false;
                                break;
                        }
                        break;
                    default:
                    break;
            }
                base.Update(gameTime, graphics, sprites);
            }
            else
            {
                canMove = true;
            }
        }

        
    }

}
