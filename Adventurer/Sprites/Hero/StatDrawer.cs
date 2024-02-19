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

namespace Adventurer.Sprites.Hero
{
    internal class StatDrawer
    {
        private static Desktop _desktop;
        private static Game1 _game;
        private static int MaxHp;
        private static int ActualHp;
        private static int DefensePoint;
        private static int Damage;
        public StatDrawer(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
        }
        public StatDrawer(int _MaxHp, int _ActualHp, int _DefensePoint, int _Damage)
        {
            MaxHp=_MaxHp;
            ActualHp= _ActualHp;
            DefensePoint= _DefensePoint;
            Damage= _Damage;
            Initialize();
        }                 

        private void Initialize()
        {
            var grid = new Grid
            {
                RowSpacing = 36,
                ColumnSpacing = 72
            };
            Window window = new Window
            {
                Title = $"Stats:     Hp:{ActualHp}/{MaxHp}",
                Width = 216,
                Height = 72,
                Background = new SolidBrush(Microsoft.Xna.Framework.Color.Black)

            };
            Grid.SetRow(window, 6);
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
            window.Content= stackPanel2;
            grid.Widgets.Add(window);
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            _desktop.Root = grid;
        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}
