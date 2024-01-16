using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Adventurer.Sprites;
using System.Collections.Generic;
using Adventurer.Sprites.Map;

namespace Adventurer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Sprite> sprites;
        Maps maps;
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

            // TODO: use this.Content to load your game content here
            sprites = new();
            #region map
            Texture2D floor = Content.Load<Texture2D>("Maps/floor");
            Texture2D wall = Content.Load<Texture2D>("Maps/wall");
            Texture2D door = Content.Load<Texture2D>("Maps/door");
            maps= new Maps(door, wall, floor);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sprites.Add(new Sprite(maps.starter_room[i, j], new Vector2(floor.Width * j, floor.Height * i)));
                }
            }
            //Texture2D current_level_background = Content.Load<Texture2D>("Maps/hero-map");
            //sprites.Add(new Sprite(current_level_background, new Vector2(0, 0)));
            _graphics.PreferredBackBufferWidth = floor.Width*10;
            _graphics.PreferredBackBufferHeight = floor.Height*10;
            _graphics.ApplyChanges();
            #endregion
            Texture2D playertexture = Content.Load<Texture2D>("Hero/hero-down");
            sprites.Add(new Player(playertexture, new Vector2(floor.Width*5,floor.Height*5)));
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