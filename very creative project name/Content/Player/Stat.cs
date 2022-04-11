using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name
{
    public class Stat
    {
        public string playerName;
        public int health;
        public int maxHealth;
        public int x, y;
        public bool canAttack;
        public int gold;
        public int potionsHeld;
        public bool isAlive;
        public int difficulty;
        public bool firstLoop;
        public List<Item> inventory = new List<Item>();

        public Stat()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerName">String: Player's name, only used for loading data</param>
        /// <param name="health">Int: Player's Current Health</param>
        /// <param name="maxHealth">Int: Player's Maximum Health</param>
        /// <param name="x">Int: Player's X Position (Left to Right)</param>
        /// <param name="y">Int: Player's Y Position (Top to Bottom)</param>
        /// <param name="attack">Bool: If the player is able to attack</param>
        /// <param name="isAlive">Bool: If the player is currently alive</param>
        /// <param name="diff">Int: The player's gameplay difficulty</param>
        /// <param name="firstLoop">Bool: If this is the first iteration of the game</param>
        /// <param name="item">Item: The items the player has.</param>
        public Stat(string playerName, int health, int maxHealth, int x, int y, bool attack, bool isAlive, int diff, bool firstLoop, Item item)
        {
            this.playerName = playerName;
            this.health = health;
            this.maxHealth = maxHealth;
            this.x = x;
            this.y = y;
            canAttack = attack;
            this.isAlive = isAlive;
            difficulty = diff;
            this.firstLoop = firstLoop;
            inventory.Add(item);
        }
    }
}
