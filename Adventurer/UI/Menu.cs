using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myra;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI.Styles;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Myra.Graphics2D;

namespace Adventurer.UI
{
    internal class Menu
    {
        private Desktop _desktop;
        private Game1 _game;
        private SoundManager _soundManager;

        public Menu(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
            Initialize();

        }

        private void Initialize()
        {
            _soundManager = new SoundManager();
            var window = new Window
            {
                Title = "Game Menu",
                Width = 300,
                Height = 400,
                Background = new SolidBrush(Microsoft.Xna.Framework.Color.Gray)

            };
            _desktop.Widgets.Add(window);
            var grid = new Grid
            {
                
                RowSpacing = 1,
                ColumnSpacing = 1,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center

            };
            window.Content = grid;
            Grid.SetColumn(window, 0);
            Grid.SetRow(window, 0);
            Grid.SetColumnSpan(window, 1);  // Set the column span to the number of columns in your grid
            Grid.SetRowSpan(window, 1);

            grid.ColumnsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());


            var titleLabel = new Label
            {
                Text = "Wanderer",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5),
                
               
            };
            grid.Widgets.Add(titleLabel);
            Grid.SetColumn(titleLabel, 0);
            Grid.SetRow(titleLabel, 0);
             

            var musicSlider = new HorizontalSlider
            {
                Minimum = 0,
                Maximum = 1,
                Width = 200,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5),
                Value = 1,
     


            };
            musicSlider.ValueChanged += (sender, args) =>
            {
                _soundManager.SetMusicVolume(musicSlider.Value);
            };
            grid.Widgets.Add(musicSlider);
            Grid.SetColumn(musicSlider, 0);
            Grid.SetRow(musicSlider, 1);

            var continueButton = new Button
            {
                Content = new Label
                {
                    Text = "Continue",
                    Padding = new Myra.Graphics2D.Thickness(10)



                },
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5),
    
            };
            continueButton.Click += (sender, args) =>
            {
                Game1.IsMenuVisible = false;
            };
            grid.Widgets.Add(continueButton);
            Grid.SetColumn(continueButton, 0);
            Grid.SetRow(continueButton, 2);

            var quitButton = new Button
            {
                Content = new Label
                {
                    Text = "Quit",
                    Padding = new Myra.Graphics2D.Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Center

                },
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
                

            };
            quitButton.Click += (sender, args) => _game.Exit();
            grid.Widgets.Add(quitButton);
            Grid.SetColumn(quitButton, 0);
            Grid.SetRow(quitButton, 3);


        }
        public void Draw()
        {
            _desktop.Render();
        }

       
    }
}
