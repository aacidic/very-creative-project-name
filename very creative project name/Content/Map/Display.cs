using System;
using System.Collections.Generic;
using static very_creative_project_name.Ref;
using System.Threading.Tasks;

namespace very_creative_project_name
{
    class Display
    {
        #region General UI (Non-dynamic fields)
        /// <summary>
        /// Creates border at bottom of the map to separate for text UI
        /// </summary>
        public void Border()
        {
            Console.SetCursorPosition(0, 44);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('▀');
            }
        }

        /// <summary>
        /// Displays the full help text with icons and split controls
        /// </summary>
        public void Help(bool inGame)
        {
            string[] controls = new string[] { "WASD", "E", "H", "I", "Q + Any Arrow Key", "ESC" };
            string[] ctrlsText = new string[] { "Move around", "Interact with objects", "Open up the help menu", "Open your inventory", "Attack your enemies", "Save and Quit (Only in Inventory)" };
            string[] icons = new string[] { "¤", "■", "O" };
            string[] iconText = new string[] { "Loot chest", "An enemy, stay away from it!", "The exit of the floor"};
            if (!inGame)
            {
                Console.Write("Before you start the game, this is also a quick guide!\nIn-game you will be able to press ");
                edit.Colour("White");
                Console.Write("[H]");
                edit.Colour("Blue");
                Console.Write(" for a simplified version of the controls and map elements.\n");

                edit.Colour("White");
                Console.Write("\nThe goal of this game is to venture as far as you can through the dungeons without dying!" +
                    "\nYou are able to attack enemies, but they have a chance of retaliating as an attack." +
                    "\nEnemies can also directly hurt you by walking directly on them." +
                    "\nYou are freely able to travel to the next floors, but not defeating all enemies will make the game harder." +
                    "\nThe floors will scale with both loot and enemies so be careful!\n\n\n");
            }
            for (int i = 0; i < controls.Length; i++)
            {
                Console.Write("[");
                edit.Colour("Green");
                Console.Write(controls[i]);
                edit.Colour("Blue");
                Console.Write("] " + ctrlsText[i] + " ");
                if (i == 2)
                {
                    Console.Write("\n");
                }
            }
            Console.Write("\n");
            for (int i = 0; i < icons.Length; i++)
            {
                Console.Write("[");
                if (i == 0) { edit.Colour("Cyan"); }
                else if (i == 1) { edit.Colour("Red"); }
                else if (i == 2) { edit.Colour("White"); }
                Console.Write(icons[i]);
                edit.Colour("Blue");
                Console.Write("] " + iconText[i] + " ");
            }
        }
        #endregion

        #region UI with input/dynamic UI
        /// <summary>
        /// Draws the map from tileType in Properties - check there for defining types
        /// </summary>
        public void DrawMap()
        {           
            for (int y = 0; y < prop.tileType.Length; y++)
            {
                for (int x = 0; x < prop.tileType[y].Length; x++)
                {
                    Console.Write(Char(prop.tileType[y][x]));
                    edit.Colour("Blue");
                }
            }
            Border();
        }

        int lastX, lastY = 1;
        /// <summary>
        /// Draws the player from the stat position
        /// </summary>
        public void DrawPlayer()
        {
            if (stats.x == 0 && stats.y == 0)
            {
            }
            else
            {
                edit.Colour("Green");
                Console.SetCursorPosition(stats.x, stats.y);
                Console.Write("■");
                edit.Colour("Blue");
                //Prevents filling player if they haven't moved positions but pressed a movement key
                if (lastX != stats.x || lastY != stats.y)
                {
                    FillLast(lastX, lastY);
                    (lastX, lastY) = (stats.x, stats.y);
                }
            }
        }

        /// <summary>
        /// Update the previous player position to return to normal
        /// </summary>
        public void FillLast(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Char(prop.tileType[y][x]));
        }

        //Initial enemy display after generation
        public void DrawEnemies(List<EnemyPoint> enemy)
        {
            foreach (EnemyPoint pos in enemy)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write(Char(2));
            }
        }

        /// <summary>
        /// Updates console display of moved enemy
        /// </summary>
        /// <param name="enemy">Enemy position</param>
        /// <param name="dir">Directional value change for cursor position</param>
        /// <param name="xDir">If movement is horizontal</param>
        public void UpdateEnemy(EnemyPoint enemy, int dir, bool xDir)
        {
            if (xDir)
            {
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(Char(2));
                if (enemy.x != enemy.x - dir)
                {
                    Console.SetCursorPosition(enemy.x - dir, enemy.y);
                    Console.Write(Char(prop.tileType[enemy.y][enemy.x]));
                }
            }
            else
            {
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(Char(2));
                if (enemy.y != enemy.y - dir)
                {
                    Console.SetCursorPosition(enemy.x, enemy.y - dir);
                    Console.Write(Char(prop.tileType[enemy.y][enemy.x]));
                }
            }
        }

        /// <summary>
        /// Displays health of the enemy
        /// </summary>
        /// <param name="health">Health of the enemy</param>
        public void EnemyHealth(int health)
        {
            string enemyHealth = "Enemy has xxxxx health left";
            
            Console.SetCursorPosition(0, 47);
            Console.WriteLine(edit.Format(enemyHealth));

            Console.SetCursorPosition(96, 47);
            edit.Colour("Green");
            for (int i = 0; i < health; i++)
            {
                Console.Write("█");
            }
            int healthLost = 5 - health;
            edit.Colour("Red");
            for (int i = 0; i < healthLost; i++)
            {
                Console.Write("█");
            }
        }

        /// <summary>
        /// Updates an individual tile on the map !! THIS WILL UPDATE THE PROPERTY TOO !!
        /// </summary>
        /// <param name="x">X position of tile to update</param>
        /// <param name="y">Y position of tile to update</param>
        /// <param name="type">The new type of tile for updating</param>
        public void UpdateTile(int x, int y, int type)
        {
            prop.tileType[y][x] = type;
            Console.SetCursorPosition(x, y);
            Console.Write(Char(type));
        }

        /// <summary>
        /// Type 0: Out of bounds
        /// Type 1: Player walkable
        /// Type 2: Enemy
        /// Type 3: Chest
        /// Type 4: Exit (To be implemented)
        /// </summary>
        /// <param name="type">Character type to return</param>
        /// <returns>Char returns character from int type</returns>
        public char Char(int type)
        {
            if (type == 0)
            {
                return '░';
            }
            else if (type == 1)
            {
                return ' ';
            }
            else if (type == 2)
            {
                edit.Colour("DarkRed");
                return '■';
            }
            else if (type == 3)
            {
                edit.Colour("Cyan");
                return '¤';
            }
            else if (type == 4)
            {
                edit.Colour("White");
                return 'O';
            }
            //This means one of the tiletypes are invalid or an incorrect number
            else
            {
                return (char)type;
            }
        }
        #endregion

        #region Tasks
        /// <summary>
        /// Makes the enemy do an all-direction attack upon being attacked.
        /// </summary>
        /// <param name="pos">Enemy positon</param>
        /// <param name="displays">Attack positions</param>
        /// <returns></returns>
        public async Task AllDirectionAttackAsync(EnemyPoint pos, int[] displays)
        {
            edit.Colour("DarkRed");
            for (int display = 0; display < 2; display++)
            {
                for (int i = 0; i < displays.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (prop.tileType[pos.y][displays[i]] == 1)
                        {
                            Console.SetCursorPosition(displays[i], pos.y);
                            if (display == 0)
                            {
                                if (stats.x == displays[i] && stats.y == pos.y)
                                {
                                    stats.health -= 1;
                                }
                                Console.Write("═");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    else
                    {
                        if (prop.tileType[displays[i]][pos.x] == 1)
                        {
                            Console.SetCursorPosition(pos.x, displays[i]);
                            if (display == 0)
                            {
                                if (stats.y == displays[i] && stats.x == pos.x)
                                {
                                    stats.health -= 1;
                                }
                                Console.Write("║");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                }
                await Task.Delay(200);
            }
            DrawPlayer();
        }
        #endregion

        #region Other
        //Displays all stats - half assigned as str half as colour to dynamically update in for loop
        public string[] Stats()
        {
            string[] stat = new string[8];
            stat[0] = "DarkYellow";
            stat[1] = stats.gold.ToString() + " Gold";
            stat[2] = "Green";
            stat[3] = stats.health.ToString() + " Health";
            if (stats.canAttack == false)
            {
                stat[4] = "Red";
                stat[5] = "Attack on Cooldown";
            }
            else
            {
                stat[4] = "Green";
                stat[5] = "    Can attack!   ";
            }
            stat[6] = "DarkRed";
            stat[7] = stats.difficulty.ToString() + " Difficulty";
            return stat;
        }
        #endregion
    }
}
