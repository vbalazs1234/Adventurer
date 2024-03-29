﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Adventurer.Sprites;
using System.Collections.Generic;
using Adventurer.Sprites.Map;
using Microsoft.Xna.Framework.Media;
using Adventurer.UI;
using Adventurer.Sprites.Item;
using Adventurer.Sprites.Hero;
using System.Diagnostics;
using System;
using Adventurer.Sprites.Enemies.Boss;
using Adventurer.Sprites.Enemies;
using System.Net.Mime;

namespace Adventurer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Sprite> sprites;
        MapsInOne maps;
        MapLoader mapLoader = new MapLoader();
        private Menu _menu;
        private PopUpText _popuptext;
        private InvDrawer _invdrawer;
        private Sprites.Hero.StatDrawer _statdrawer;
        private Sprites.Enemies.StatDrawer statDrawer;
        public static bool IsMenuVisible;
        private KeyboardState previousKeyboardState;
        Texture2D playertexture;
        Texture2D enemyTexture;
        Texture2D bossTexture;
        Player player;
        Boss boss;
        private int level=1;
        PositionEvents events = new PositionEvents();
        List<Enemy> enemies = new List<Enemy>();

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
            _invdrawer = new InvDrawer(this);
            _statdrawer = new Sprites.Hero.StatDrawer(this);
            statDrawer = new Sprites.Enemies.StatDrawer(this);
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
            maps = new MapsInOne();
            
            MapsInOne.isOpened = false;
            doors.LoadContent(Content);
            sound.LoadContent(Content);
            beformaps.LoadContent(Content);
            objects.LoadContent(Content);
            if (MapsInOne.nextLevel)
            {
                player.BackToTheStrat();
                MagnifyingGlass.keycollected = false;
                level++;
            }
            MapsInOne.nextLevel = false;
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
            enemyTexture = Content.Load<Texture2D>("Enemies/hero-down");
            bossTexture = Content.Load<Texture2D>("Enemies/Bosses/Boss1/boss");
            //boss = new Boss(bossTexture, new Vector2(distance*5,distance*5),level);
            if (playertexture == null)
            {
                 playertexture = Content.Load<Texture2D>("Hero/hero-down");
                 player = new Player(playertexture, new Vector2(distance * 5, distance * 5));
            }
            sprites.Add(player);
            //sprites.Add(boss);
            

        }

        protected override void Update(GameTime gameTime)
        {
            if (MapsInOne.nextLevel)
            {
                LoadContent();
            }
            #region Fight
            for (int i = 0; i < enemies.Count; i++)
            {
                events.fightTest(player, enemies[i]);
                if (enemies[i].HP <= 0) 
                {
                    player.collectExp((enemies[i].level * 10)+10);
                    sprites.Remove(enemies[i]);

                    if (enemies[i] == boss)
                    {
                        MapsInOne.nextLevel = true;
                    }

                    enemies.Remove(enemies[i]);
                }
                if (player.ActualHp <= 0)
                {
                    System.Environment.Exit(1);
                }
            }
                
            #endregion
            // TODO: Add your update logic here
            #region EnemySpawning
            if (MapsInOne.PlayerMapPosition_X < 5)
            {
            if(!maps.maps[MapsInOne.PlayerMapPosition_Y, MapsInOne.PlayerMapPosition_X].hadEnemies)
            {
                Random rand= new Random();
                int distance = Maps.floor.Height;
                    int enemyAmount = rand.Next(0, 7);
                for (int i = 0; i < enemyAmount; i++)
                {
                        int pozA = 0;
                        int pozB = 0;
                        do
                        {
                            pozA = rand.Next(2, 9);
                            pozB = rand.Next(2, 9);

                        } while (maps.maps[MapsInOne.PlayerMapPosition_Y, MapsInOne.PlayerMapPosition_X].starter_room[pozB,pozA].Name == "Maps/wall");
                    enemies.Add(new Enemy(enemyTexture, new Vector2(distance * pozA , distance *pozB), level));
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    sprites.Add(enemies[i]);
                }
                maps.maps[MapsInOne.PlayerMapPosition_Y, MapsInOne.PlayerMapPosition_X].hadEnemies=true;
            }
            }
            #endregion
            #region MapLoading
            IsItaWall.enemyCount = enemies.Count;
            if (MapsInOne.keyChange)
            {
                for (int i = 0; i < mapLoader.loadMap(maps).Count; i++)
                {
                    sprites[i] = mapLoader.loadMap(maps)[i];
                }
                MapsInOne.keyChange = false;
            }
            if (MapsInOne.PreviousPlayerMapPosition_X != MapsInOne.PlayerMapPosition_X)
            {
                for (int i = 0; i < mapLoader.loadMap(maps).Count; i++)
                {
                    sprites[i]=mapLoader.loadMap(maps)[i];
                }
                MapsInOne.PreviousPlayerMapPosition_X = MapsInOne.PlayerMapPosition_X;
                if (MapsInOne.PlayerMapPosition_X == 5)
                {
                    boss = new Boss(bossTexture, new Vector2(72 * 5, 72 * 5), level);
                    enemies.Add(boss);
                    sprites.Add(enemies[0]);
                }
            }
            else if(MapsInOne.PreviousPlayerMapPosition_Y != MapsInOne.PlayerMapPosition_Y)
            {
                for (int i = 0; i < mapLoader.loadMap(maps).Count; i++)
                {
                    sprites[i] = mapLoader.loadMap(maps)[i];
                }
                MapsInOne.PreviousPlayerMapPosition_Y = MapsInOne.PlayerMapPosition_Y;
            }
            #endregion
            #region TextureRefresh
            foreach (var item in sprites)
            {
                if (item is Player)
                {
                    item.Texture = Content.Load<Texture2D>(Player.player_image_name);
                }
                if (item is Enemy)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (item == enemies[i]) item.Texture = Content.Load<Texture2D>(enemies[i].enemy_image_name);
                    }
                }
            }
            #endregion
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape) && !previousKeyboardState.IsKeyDown(Keys.Escape))
            {
                IsMenuVisible =  !IsMenuVisible;
                Sprites.Hero.StatDrawer.showAll = false;

            }
            else if(keyboardState.IsKeyDown(Keys.Tab) && !previousKeyboardState.IsKeyDown(Keys.Tab))
            {
                if(!IsMenuVisible)Sprites.Hero.StatDrawer.showAll = !Sprites.Hero.StatDrawer.showAll;
            }
            previousKeyboardState = keyboardState;
            foreach (var sprite in sprites)
            {
                if (sprite is not Enemy)
                {
                    sprite.Update(gameTime, _graphics, sprites);
                }
            }
            #region EnemyMovement
            if (Player.Moves % 3 == 0)
            {
                foreach (var sprite in sprites)
                {

                    if (sprite is Enemy && Player.Moves % 3 == 0)
                    {
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            if (sprite == enemies[i])
                            {
                                enemies[i].canMove = true;
                            }
                        }
                        sprite.Update(gameTime, _graphics, sprites);
                    }
                }
                    Player.Moves++;
            }
            #endregion
            #region ObjectReffresher
            if (MapsInOne.objectChange)
            {
                maps.removeObject();
                for (int i = 0; i < mapLoader.loadMap(maps).Count; i++)
                {
                    sprites[i] = mapLoader.loadMap(maps)[i];
                }
            }
            #endregion
            base.Update(gameTime);
                    
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.SlateGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var sprite in sprites)
            {
                if (sprite is Boss)
                {
                sprite.Draw(_spriteBatch, 2f);
                }
                else
                {
                    sprite.Draw(_spriteBatch, 1f);
                }
            }
            
            if (IsMenuVisible)
            {

                DrawBackgroundWindow(new Rectangle(72 * 3, 36 * 7, 72 * 4, 72 * 3));
            }
            _spriteBatch.End();
            _invdrawer.Draw();
            _statdrawer.Draw();
            foreach (var item in sprites)
            {
                if(item is Enemy)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (events.showEnemyStats(player, enemies[i]) && enemies[i]==item)
                        {
                            statDrawer.Draw();
                        }
                    }
                }
            }
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