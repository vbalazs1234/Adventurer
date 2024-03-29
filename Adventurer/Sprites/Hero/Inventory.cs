﻿using Adventurer.Sprites.Item;
using Adventurer.Sprites.Map;
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
            itemStoredCounter();
            if(collectedItemCount < 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (items[i] == null) { items[i] = item; MapsInOne.objectChange = true; break; }
                }
            }
        }
        public void RemoveItem(Items item,int chosenItem)
        {
            if(item.Durability <=0)
            {
                items[chosenItem] = null;
            }
            itemStoredCounter();
        }
        public void itemStoredCounter()
        {
            collectedItemCount = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null) collectedItemCount++;
            }
        }
    }
}
