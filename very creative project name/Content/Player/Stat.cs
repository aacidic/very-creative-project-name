using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name
{
    class Stat
    {
        public int health;
        public int x, y;
        public int dodgeChance;
        public int critChance;
        public int gold;
        public List<Item> inventory;
        
        public Stat()
        {

        }

        public Stat(int health, int x, int y, Item item)
        {
            this.health = health;
            this.x = x;
            this.y = y;
            inventory.Add(item);
        }
    }
}
