using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Adventurer.Sprites;
using System.Collections.Generic;
using Adventurer.Sprites.Map;
using Microsoft.Xna.Framework.Media;
using Adventurer.UI;
using Adventurer.Sprites.Item;

namespace Adventurer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Sprite> sprites;
        MapsInOne maps = new MapsInOne();
        MapLoader mapLoader = new MapLoader();
        private Menu _menu;
        private PopUpText _popuptext;
        public static bool IsMenuVisible;
        private KeyboardState previousKeyboardState;
        Texture2D playertexture;
        Texture2D enemyTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _menu = new Menu(this);
            _popuptext = new PopUpText(this);
            IsMenuVisible = false;
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Doors doors = new Doors();
            Objects objects = new Objects();
            SoundManager sound = new SoundManager();
            Maps beformaps = new Maps(1,1);
            doors.LoadContent(Content);
            sound.LoadContent(Content);
            beformaps.LoadContent(Content);
            objects.LoadContent(Content);
           
            maps.fill();
            SoundManager.PlayMusic();
            // TODO: use this.Content to load your game content here
            sprites = new();
            #region map
            int distance = Maps.floor.Height;
            sprites= mapLoader.loadMap(maps);
            _graphics.PreferredBackBufferWidth = distance * 10;
            _graphics.PreferredBackBufferHeight = distance * 10;
            _graphics.ApplyChanges();
            #endregion
            IsItaWall.spriteses = sprites;
            enemyTexture = Content.Load<Texture2D>("Enemies/Goblin/goblindown");
            sprites.Add(new Enemy(enemyTexture, new Vector2(distance * 2, distance * 2)));
            playertexture = Content.Load<Texture2D>("Hero/hero-down");
            sprites.Add(new Player(playertexture, new Vector2(distance *5,distance *5)));
          
        }

        protected override void Update(GameTime gameTime)
        {
          
            
           
            // TODO: Add your update logic here
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime,_graphics, sprites);
            }
            if (MapsInOne.objectChange)
            {
                for (int i = 0; i < sprites.Count - 2; i++)
                {
                    sprites[i] = mapLoader.loadMap(maps)[i];
                }
                MapsInOne.objectChange = false;
            }
            if (MapsInOne.PreviousPlayerMapPosition_X != MapsInOne.PlayerMapPosition_X)
            {
                for (int i = 0; i < sprites.Count-2; i++)
                {
                    sprites[i]=mapLoader.loadMap(maps)[i];
                }
                MapsInOne.PreviousPlayerMapPosition_X = MapsInOne.PlayerMapPosition_X;
            }
            else if(MapsInOne.PreviousPlayerMapPosition_Y != MapsInOne.PlayerMapPosition_Y)
            {
                for (int i = 0; i < sprites.Count - 2; i++)
                {
                    sprites[i] = mapLoader.loadMap(maps)[i];
                }
                MapsInOne.PreviousPlayerMapPosition_Y = MapsInOne.PlayerMapPosition_Y;
            }
            sprites[sprites.Count-1].Texture = Content.Load<Texture2D>(Player.player_image_name);
            
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape) && !previousKeyboardState.IsKeyDown(Keys.Escape))
            {
                IsMenuVisible =  !IsMenuVisible;
            }
            previousKeyboardState = keyboardState;
            foreach (var sprite in sprites)
            {
                if (sprite is Enemy)
                {
                    sprite.Update(gameTime, _graphics, sprites);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.SlateGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }
            
            if (IsMenuVisible)
            {

                DrawBackgroundWindow(new Rectangle(72 * 3, 36 * 7, 72 * 4, 72 * 3));
            }
            _spriteBatch.End();
            if(PopUpText.showTexts)
            {
                _popuptext.Draw();
            }
            if (IsMenuVisible)
            {
                _menu.Draw();
            }
            base.Draw(gameTime);
        }

        private void DrawBackgroundWindow(Rectangle rectangle)
        {
            // Create a texture for the gray window
            Texture2D grayTexture = new Texture2D(GraphicsDevice, 1, 1);
            grayTexture.SetData(new Color[] { Color.Gray });

            // Draw the gray window
            _spriteBatch.Draw(grayTexture, rectangle, Color.White);
        }
    }
}