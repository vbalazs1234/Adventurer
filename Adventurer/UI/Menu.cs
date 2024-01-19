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

        public Menu(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
            Initialize();

        }

        private void Initialize()
        {

            var grid = new Grid
            {
                RowSpacing = 4,
                ColumnSpacing = 4
            };

            var titleLabel = new Label
            {
                Text = "Wanderer",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5)
            };
            grid.Widgets.Add(titleLabel);
            Grid.SetColumn(titleLabel, 0);
            Grid.SetRow(titleLabel, 0);

            var musicSlider = new HorizontalSlider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                Width = 200,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5)
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
                Margin = new Thickness(5)
            };
            continueButton.Click += (sender, args) =>
            {
                //logic
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

            _desktop.Root = grid;

        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}
