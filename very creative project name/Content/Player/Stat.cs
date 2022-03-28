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
        public bool canAttack;
        public int gold;
        public bool isAlive;
        public int difficulty;
        public List<Item> inventory = new List<Item>();

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
        /// <param name="attack">If player can attack</param>
        /// <param name="item">Individual item to add to inventory</param>
        public Stat(int health, int x, int y, int dodge, bool attack, bool isAlive, int diff, Item item)
        {
            this.health = health;
            this.x = x;
            this.y = y;
            dodgeChance = dodge;
            canAttack = attack;
            this.isAlive = isAlive;
            difficulty = diff;
            inventory.Add(item);
        }
    }
}
