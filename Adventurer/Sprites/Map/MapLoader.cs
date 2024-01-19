using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adventurer.Sprites.Map
{
    internal class MapLoader
    {
        List<Sprite> sprites;
        public List<Sprite> loadMap(MapsInOne maps)
        {
            maps.chanegeDoor();
            sprites = new();
            int distance = Maps.floor.Height;
            for (int a = 0; a < 2; a++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (a == 0)
                        {
                            sprites.Add(new Sprite(
                                maps.maps[MapsInOne.PlayerMapPosition_Y, MapsInOne.PlayerMapPosition_X].starter_room[i, j],
                                new Vector2(distance * j, distance * i)));
                        }
                        else
                        {
                            sprites.Add(new Sprite(
                                maps.maps[MapsInOne.PlayerMapPosition_Y, MapsInOne.PlayerMapPosition_X].objects[i, j],
                                new Vector2(distance * j, distance * i)));
                        }
                    }
                }

            }
            return sprites;
        }
    }
}
