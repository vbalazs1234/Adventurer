using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventurer.Sprites.Map;

namespace Adventurer.Sprites.Item
{
    internal class MagnifyingGlass : Items
    {

        public MagnifyingGlass()
        {
            Name = "Magnifying Glass";
            Description = "Shows which room the key is in.";
            Durability = 1;
            Damage = 0;
        }

        public override void useItem()
        {
            showText = $"The key is located in Y: {Maps.keyRoomPozition_Y+1} and X: {Maps.keyRoomPozition_X+1} room.";
            PopUpText text = new PopUpText(showText);
            damageItem();
        }


    }
}
