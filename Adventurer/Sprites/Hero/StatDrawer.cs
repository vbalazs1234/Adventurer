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
        private static int Experience;
        private static int Level;
        public static bool showAll=false;
        public StatDrawer(Game1 game)
        {
            _game = game;
            MyraEnvironment.Game = game;
            _desktop = new Desktop();
        }
        public StatDrawer(int _MaxHp, int _ActualHp, int _DefensePoint, int _Damage,int exp,int level)
        {
            MaxHp=_MaxHp;
            ActualHp= _ActualHp;
            DefensePoint= _DefensePoint;
            Damage= _Damage;
            Experience= exp;
            Level= level;
            Initialize();
        }                 

        private void Initialize()
        {
            var grid = new Grid{};
            if (showAll)
            {
                Window window = new Window
                {
                    Title = $"Stats:",
                    Width = 216,
                    Height = 144,
                    Background = new SolidBrush(Microsoft.Xna.Framework.Color.Black)

                };
                
                window.DragDirection = DragDirection.None;
                window.CloseButton.Enabled = false;
                window.CloseButton.Visible = false;
                var stackPanel  = new VerticalStackPanel  {Spacing = 8};
                var stackPanel2 = new HorizontalStackPanel{Spacing = 8};
                var stackPanel3 = new HorizontalStackPanel{Spacing = 8};
                var stackPanel4 = new HorizontalStackPanel{Spacing = 8};
                
                var def = new Label()
                {
                    Text = $"Armor:{DefensePoint}"
                };
                var dam = new Label()
                {
                    Text = $"Damage:{Damage}"
                };
                var exp = new Label()
                {
                    Text = $"Exp:{Experience}/{Level * 100}"
                };
                var level = new Label()
                {
                    Text = $"Level:{Level}"
                };
                var hp = new Label()
                {
                    Text = $"Hp:{ActualHp}/{MaxHp}"
                };

                stackPanel2.Widgets.Add(level); stackPanel2.Widgets.Add(hp);
                stackPanel3.Widgets.Add(def); stackPanel3.Widgets.Add(dam);
                stackPanel4.Widgets.Add(exp);
                stackPanel.Widgets.Add(stackPanel2); stackPanel.Widgets.Add(stackPanel3); stackPanel.Widgets.Add(stackPanel4);
                //stackPanel.VerticalAlignment = VerticalAlignment.Center;
                stackPanel2.HorizontalAlignment = HorizontalAlignment.Center;
                stackPanel3.HorizontalAlignment = HorizontalAlignment.Center;
                stackPanel4.HorizontalAlignment = HorizontalAlignment.Center;
                window.Content= stackPanel;
                grid.Widgets.Add(window);
                grid.HorizontalAlignment = HorizontalAlignment.Center;
                grid.VerticalAlignment = VerticalAlignment.Center;
            }
            else
            {
                Window window = new Window
                {
                    Title = $"Stats:",
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

                var level = new Label()
                {
                    Text = $"Level:{Level}"
                };
                var hp = new Label()
                {
                    Text = $"Hp:{ActualHp}/{MaxHp}"
                };

                stackPanel2.Widgets.Add(level); stackPanel2.Widgets.Add(hp);
                stackPanel2.HorizontalAlignment = HorizontalAlignment.Center;
                window.Content = stackPanel2;
                grid.Widgets.Add(window);
                grid.HorizontalAlignment = HorizontalAlignment.Left;
                grid.VerticalAlignment = VerticalAlignment.Bottom;
            }
            
            _desktop.Root = grid;
        }
        public void Draw()
        {
            _desktop.Render();
        }
    }
}
