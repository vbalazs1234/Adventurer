using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myra;
using Myra.Graphics2D.UI;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.Brushes;
using Adventurer.Sprites.Map;
using Microsoft.Xna.Framework;

namespace Adventurer.Sprites.Hero
{
    internal class InvDrawer
    {
        private static Desktop _desktop;
        private static Game1 _game;
        private Inventory _inventory;
        private static int selected;
        public InvDrawer(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
            Initialize();
        }
        public InvDrawer(Inventory inventory, int _selected)
        {
            _inventory = inventory;
            Initialize();
            selected = _selected;
        }
        private void Initialize()
        {
            var grid = new Grid
            {
                RowSpacing = 36,
                ColumnSpacing = 36
            };
            Myra.Graphics2D.UI.Window window = new Myra.Graphics2D.UI.Window
            {
                Title = "Inventory",
                Width = 216,
                Height = 72,
                Background = new SolidBrush(Microsoft.Xna.Framework.Color.Black)

            };
            Grid.SetRow(window, 6);
            Grid.SetColumn(window, 2);
            window.DragDirection = DragDirection.None;
            window.CloseButton.Enabled = false;
            window.CloseButton.Visible = false;

            var item = new ComboView();
            for (int i = 0; i < 5; i++)
            {
            var text = new Label();
            text.Text = (i + 1).ToString();
                if (_inventory != null)
                {

                    if (_inventory.items[i] != null)
                    {
                        text.Text= (i + 1)+" " + _inventory.items[i].Name;
                        item.Widgets.Add(text);                        
                    }
                    else {
                        item.Widgets.Add(text);
                    }
                }
                else
                {
                    item.Widgets.Add(text);
                }
            }
                item.SelectedIndex  = selected;
                item.Enabled = false;
                window.Content = item;
            grid.Widgets.Add(window);

            _desktop.Root = grid;
        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}
