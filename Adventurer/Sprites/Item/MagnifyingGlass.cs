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
        public static bool keycollected=false;
        public MagnifyingGlass()
        {
            Name = "Magnifying Glass";
            Description = "Shows which room the key is in.";
            Durability = 1;
            Damage = 0;
        }

        public override void useItem()
        {
            if (!keycollected)
            {
            showText = $"The key is located in Y: {Maps.keyRoomPozition_Y+1} and X: {Maps.keyRoomPozition_X+1} room.";
            }
            else
            {
                showText = "Key has been collected!  ";
            }
            PopUpText text = new PopUpText(showText);
            damageItem();
        }


    }
}
