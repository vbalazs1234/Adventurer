using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myra;
using Myra.Graphics2D.UI;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;

namespace Adventurer.Sprites.Item
{
    internal class PopUpText
    {
        public static bool showTexts;
        private static Desktop _desktop;
        private static Game1 _game;
        private static string _text;
        private int length;
        public PopUpText(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
        }
        public PopUpText(string text)
        {
            _text = text;
            length = text.ToCharArray().Count()*8;
            Initialize();
        }
        private void Initialize()
        {
            var grid = new Grid
            {
                RowSpacing = 4,
                ColumnSpacing = 4
            };
            var window = new Window
            {
                Title = _text,
                Width = length,
                Height = 25,
                Background = new SolidBrush(Microsoft.Xna.Framework.Color.Gray)

            };
            Grid.SetRow(window, 3);
            grid.Widgets.Add(window);
            window.CloseButton.Enabled = false;
            window.CloseButton.Visible = false;
            _desktop.Root= grid;
        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}
