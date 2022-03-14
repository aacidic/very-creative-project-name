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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="health">Player Health</param>
        /// <param name="x">Player X Position</param>
        /// <param name="y">Player Y Position</param>
        /// <param name="dodge">Player Dodge Chance</param>
        /// <param name="crit">Player Crit Chance</param>
        /// <param name="item">Individual item to add to inventory</param>
        public Stat(int health, int x, int y, int dodge, int crit, Item item)
        {
            this.health = health;
            this.x = x;
            this.y = y;
            dodgeChance = dodge;
            critChance = crit;
            inventory.Add(item);
        }
    }
}
