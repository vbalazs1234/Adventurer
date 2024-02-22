using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Myra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites.Enemies
{
    internal class StatDrawer
    {
        private static Desktop _desktop;
        private static Game1 _game;
        private static int ActualHp;
        private static int DefensePoint;
        private static int Damage;
        private static int Level;
        public StatDrawer(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
        }
        public StatDrawer(int _ActualHp, int _DefensePoint, int _Damage, int level)
        {
            
            ActualHp = _ActualHp;
            DefensePoint = _DefensePoint;
            Damage = _Damage;
            Level = level;
            Initialize();
        }

        private void Initialize()
        {
            var grid = new Grid
            {
            };
            Window window = new Window
            {
                Title = $"Stats: Level:{Level} Hp:{ActualHp}",
                Width = 216,
                Height = 72,
                Background = new SolidBrush(Microsoft.Xna.Framework.Color.Black)

            };
            Grid.SetRow(window, 0);
            Grid.SetColumn(window, 0);
            window.DragDirection = DragDirection.None;
            window.CloseButton.Enabled = false;
            window.CloseButton.Visible = false;
            var stackPanel2 = new HorizontalStackPanel
            {
                Spacing = 8
            };

            var def = new Label()
            {
                Text = $"Armor:{DefensePoint}"
            };
            var dam = new Label()
            {
                Text = $"Damage:{Damage}"
            };
            
            stackPanel2.Widgets.Add(def); stackPanel2.Widgets.Add(dam);
            stackPanel2.HorizontalAlignment = HorizontalAlignment.Center;
            window.Content = stackPanel2;
            grid.Widgets.Add(window);
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            _desktop.Root = grid;
        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}

