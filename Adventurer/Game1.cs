using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Adventurer.Sprites;
using System.Collections.Generic;
using Adventurer.Sprites.Map;
using Microsoft.Xna.Framework.Media;

namespace Adventurer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Sprite> sprites;
        MapsInOne maps = new MapsInOne();
        MapLoader mapLoader = new MapLoader();
        Texture2D playertexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Doors doors = new Doors();
            SoundManager sound = new SoundManager();
            Maps beformaps = new Maps(1,1);
            doors.LoadContent(Content);
            sound.LoadContent(Content);
            beformaps.LoadContent(Content);
           
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
            playertexture = Content.Load<Texture2D>("Hero/hero-down");
            sprites.Add(new Player(playertexture, new Vector2(distance *5,distance *5)));
          
        }

        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            // TODO: Add your update logic here
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime,_graphics);
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
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}