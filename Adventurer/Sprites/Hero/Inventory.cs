using Adventurer.Sprites.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adventurer.Sprites.Hero
{
    internal class Inventory
    {
        public int collectedItemCount;
        public Items[] items;
        public Inventory()
        {
            items = new Items[5];
            collectedItemCount = 0;
        }
        public void pickUpItem(Items item)
        {
            if(collectedItemCount < 5)
            {
            items[collectedItemCount] = item;
            collectedItemCount++;
            }
        }
        public void RemoveItem(Items item,int chosenItem)
        {
            if(item.Durability <=0)
            {
                items[chosenItem] = null;
                collectedItemCount--;
            }
        }
    }
}
