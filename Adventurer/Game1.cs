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
        Maps maps;
        //SoundManager soundManager;
        Song song;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //soundManager = new SoundManager(this);
            
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
            song = Content.Load<Song>("Sounds/background-music");
            MediaPlayer.Play(song);
            // TODO: use this.Content to load your game content here
            sprites = new();
            #region map
            Texture2D floor = Content.Load<Texture2D>("Maps/floor");
            Texture2D wall = Content.Load<Texture2D>("Maps/wall");
            Texture2D door = Content.Load<Texture2D>("Maps/door");
            Texture2D torch = Content.Load<Texture2D>("Maps/torch");
            Texture2D filler = Content.Load<Texture2D>("Maps/filler");
            maps = new Maps(door, wall, floor,torch,filler);
            for (int a = 0; a < 2; a++)
            {
                if (a == 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            sprites.Add(new Sprite(maps.starter_room[i, j], new Vector2(floor.Width * j, floor.Height * i)));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            sprites.Add(new Sprite(maps.objects[i, j], new Vector2(floor.Width * j, floor.Height * i)));
                        }
                    }
                }
            }
            
            _graphics.PreferredBackBufferWidth = floor.Width*10;
            _graphics.PreferredBackBufferHeight = floor.Height*10;
            _graphics.ApplyChanges();
            #endregion
            List<Sprite> idk=new List<Sprite>(sprites);
            IsItaWall.spriteses = idk;
            Texture2D playertexture = Content.Load<Texture2D>("Hero/hero-down");
            sprites.Add(new Player(playertexture, new Vector2(floor.Width*5,floor.Height*5)));
          
        }

        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //soundManager.Update();
           

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