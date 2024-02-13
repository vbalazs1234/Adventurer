using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventurer.Sprites.Hero;
using Adventurer.Sprites.Item;
using Adventurer.Sprites.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Adventurer.Sprites
{
    internal class Player : Sprite
    {
        public int MaxHp;
        public int ActualHp;
        public int DefensePoint;
        public int Damage;
        public static string player_image_name = "Hero/hero-down";
        private Texture2D player_image;
        public bool canMove = true;
        public static bool doorunlocked = true;
        private IsItaWall isItaWall = new IsItaWall();
        private Inventory inv;
        private int selectedItem;
        public static int Moves { get; set; }
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            player_image = texture;
            MaxHp = 20 + 3 * Randomizer.RandomNum();
            ActualHp = MaxHp;
            DefensePoint = 2 * Randomizer.RandomNum();
            Damage = 5 + Randomizer.RandomNum();
            selectedItem= 0;
            inv = new Inventory();
            Moves = 1;
        }

        public void LevelUp()
        {
            MaxHp += Randomizer.RandomNum();
            ActualHp = MaxHp;
            DefensePoint += Randomizer.RandomNum();
            Damage += Randomizer.RandomNum();
        }

        public override void Update(GameTime gameTime, GraphicsDeviceManager _graphics, List<Sprite> sprites)
        {
            base.Update(gameTime,_graphics, sprites);
            #region Movement
            if (Keyboard.GetState().IsKeyDown(Keys.W) && canMove != false)
            {
                canMove = false;
                switch (isItaWall.Is_it_a_wall_upward(Position))
                {
                    case 1:
                        player_image_name = "Hero/hero-up";
                        break;
                    case 2:
                        player_image_name = "Hero/hero-up";
                        if (MapsInOne.PlayerMapPosition_Y > 0)
                        {
                            Position.Y = _graphics.PreferredBackBufferHeight - (player_image.Width * 2);
                            MapsInOne.PlayerMapPosition_Y--;
                        }
                        Moves++;
                        break;
                    case 3:
                        MapsInOne.isOpened = true;
                        MapsInOne.objectChange= true;
                        Position.Y -= player_image.Height;
                        player_image_name = "Hero/hero-up";
                        Moves++;
                        break;
                    case 4:
                        MagnifyingGlass magnifyingGlass = new MagnifyingGlass();
                        inv.pickUpItem(magnifyingGlass);
                        Position.Y -= player_image.Height;
                        player_image_name = "Hero/hero-up";
                        Moves++;
                        break;
                    default:
                        Position.Y -= player_image.Height;
                        player_image_name = "Hero/hero-up";
                        Moves++;
                        break;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && canMove != false)
            {
                canMove = false;
                switch (isItaWall.Is_it_a_wall_downward(Position))
                {
                case 1:
                    player_image_name = "Hero/hero-down";
                    break;
                case 2:
                    player_image_name = "Hero/hero-down";
                        if (MapsInOne.PlayerMapPosition_Y < 4)
                        {
                            Position.Y = 0 + player_image.Width;
                            MapsInOne.PlayerMapPosition_Y++;
                        }
                        Moves++;
                        break;
                    case 3:
                        MapsInOne.isOpened = true;
                        MapsInOne.objectChange = true;
                        Position.Y += player_image.Height;
                        player_image_name = "Hero/hero-down";
                        Moves++;
                        break;
                    case 4:
                        MagnifyingGlass magnifyingGlass = new MagnifyingGlass();
                        inv.pickUpItem(magnifyingGlass);
                        Position.Y += player_image.Height;
                        player_image_name = "Hero/hero-down";
                        Moves++;
                        break;
                    default:
                    Position.Y += player_image.Height;
                    player_image_name = "Hero/hero-down";
                        Moves++;
                        break;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && canMove != false)
            {
                canMove = false;
                switch (isItaWall.Is_it_a_wall_left(Position))
                {
                    case 1:
                        player_image_name = "Hero/hero-left";
                        break;
                    case 2:
                        player_image_name = "Hero/hero-left";
                        if (MapsInOne.PlayerMapPosition_X > 0)
                        {
                            Position.X = _graphics.PreferredBackBufferWidth - (player_image.Width * 2);
                            MapsInOne.PlayerMapPosition_X--;
                        }
                        Moves++;
                        break;
                    case 3:
                        MapsInOne.isOpened = true;
                        MapsInOne.objectChange = true;
                        Position.X -= player_image.Width;
                        player_image_name = "Hero/hero-left";
                        Moves++;
                        break;
                    case 4:
                        MagnifyingGlass magnifyingGlass = new MagnifyingGlass();
                        inv.pickUpItem(magnifyingGlass);
                        Position.X -= player_image.Width;
                        player_image_name = "Hero/hero-left";
                        Moves++;
                        break;
                    default:
                Position.X -= player_image.Width;
                player_image_name = "Hero/hero-left";
                        Moves++;
                        break;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && canMove != false)
            {
                canMove = false;
                switch (isItaWall.Is_it_a_wall_right(Position))
                {
                    case 1:
                        player_image_name = "Hero/hero-right";
                        break;
                    case 2:
                        player_image_name = "Hero/hero-right";
                        if (MapsInOne.PlayerMapPosition_X < 4)
                        {
                            Position.X = 0 + player_image.Width;
                            MapsInOne.PlayerMapPosition_X++;
                        }
                        Moves++;
                        break;
                    case 3:
                        MapsInOne.isOpened = true;
                        MapsInOne.objectChange = true;
                        Position.X += player_image.Width;
                        player_image_name = "Hero/hero-right";
                        Moves++;
                        break;
                    case 4:
                        MagnifyingGlass magnifyingGlass = new MagnifyingGlass();
                        inv.pickUpItem(magnifyingGlass);
                        Position.X += player_image.Width;
                        player_image_name = "Hero/hero-right";
                        Moves++;
                        break;
                    case 5:
                        player_image_name = "Hero/hero-right";
                        Position.X = 0 + player_image.Width;
                        Moves++;
                        break;
                    case 6:
                        player_image_name = "Hero/hero-right";
                        Moves++;
                        break;
                    default:
                    Position.X += player_image.Width;
                    player_image_name = "Hero/hero-right";
                        Moves++;
                        break;
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.E) && canMove != false)
            {
                canMove=false;
                if (selectedItem < 4)
                {
                selectedItem++;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q) && canMove != false)
            {
                canMove = false;
                if (selectedItem > 0)
                {
                    selectedItem--;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F) && canMove != false)
            {
                canMove = false;
                if (inv.items[selectedItem] != null)
                {
                if (PopUpText.showTexts)
                {
                    PopUpText.showTexts = false;
                    inv.RemoveItem(inv.items[selectedItem],selectedItem);
                }
                else
                {
                    inv.items[selectedItem].useItem();
                    PopUpText.showTexts = true;
                }
                }
                
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F) && Keyboard.GetState().IsKeyUp(Keys.Q) && Keyboard.GetState().IsKeyUp(Keys.E) && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D) && canMove == false)
            {
                canMove = true;
            }
            #endregion
            #region border

            if (Position.X > _graphics.PreferredBackBufferWidth - player_image.Width)
            {
                Position.X = _graphics.PreferredBackBufferWidth - player_image.Width;
            }
            else if (Position.X < 0)
            {
                Position.X = 0;
            }

            if (Position.Y > _graphics.PreferredBackBufferHeight - player_image.Height)
            {
                Position.Y = _graphics.PreferredBackBufferHeight - player_image.Height;
            }
            else if (Position.Y < 0)
            {
                Position.Y = 0;
            }
            #endregion
        }
    }
}
