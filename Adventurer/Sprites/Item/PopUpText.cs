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

namespace Adventurer.Sprites.Item
{
    internal class PopUpText
    {
        public static bool showTexts;
        private static Desktop _desktop;
        private static Game1 _game;
        private static string _text;
        public PopUpText(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
            Initialize();
        }
        public PopUpText(string text)
        {
            _text = text;
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
                Text = _text,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5),
            };
            titleLabel.OverTextColor = Microsoft.Xna.Framework.Color.Black;
            titleLabel.TextColor = Microsoft.Xna.Framework.Color.Black;
            grid.Widgets.Add(titleLabel);
            Grid.SetColumn(titleLabel, 0);
            Grid.SetRow(titleLabel, 2);
            _desktop.Root = grid;
        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}
