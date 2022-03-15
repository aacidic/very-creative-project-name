using System;
using System.Collections.Generic;
using static very_creative_project_name.Ref;

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
            string[] controls = new string[] { "WASD", "E", "M", "H", "I", "Q", "ESC" };
            string[] ctrlsText = new string[] { "Move around", "Interact with objects", "Resize your map", "Open up the help menu", "Open your inventory", "Attack your enemies", "Save and quit" };
            string[] icons = new string[] { "¤", "■" };
            string[] iconText = new string[] { "Loot chest", "An enemy, stay away from it!"};
            if (!inGame)
            {
                Console.Write("Before you start the game, this is also a quick guide!\nIn-game you will be able to press ");
                edit.Colour("White");
                Console.Write("[H]");
                edit.Colour("Blue");
                Console.Write(" for a simplified version of the controls and map elements.\n");
            }
            for (int i = 0; i < controls.Length; i++)
            {
                Console.Write("[");
                edit.Colour("Green");
                Console.Write(controls[i]);
                edit.Colour("Blue");
                Console.Write("] " + ctrlsText[i] + " ");
                if (i == 3)
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
        public void DrawPlayer(int x, int y)
        {
            edit.Colour("Green");
            Console.SetCursorPosition(x, y);
            Console.Write("■");
            edit.Colour("Blue");
            //Prevents filling player if they haven't moved positions but pressed a movement key
            if (lastX != x || lastY != y)
            {
                FillLast(lastX, lastY);
                (lastX, lastY) = (x, y);
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
        public void DrawEnemies(List<Point> enemy)
        {
            foreach (Point pos in enemy)
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
        public void UpdateEnemy(Point enemy, int dir, bool xDir)
        {
            if (xDir)
            {
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(Char(2));
                Console.SetCursorPosition(enemy.x - dir, enemy.y);
                Console.Write(Char(prop.tileType[enemy.y][enemy.x]));
            }
            else
            {
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(Char(2));
                Console.SetCursorPosition(enemy.x, enemy.y - dir);
                Console.Write(Char(prop.tileType[enemy.y][enemy.x]));
            }
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
            //This means one of the tiletypes are invalid or an incorrect number
            else
            {
                return (char)type;
            }
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
            stat[4] = "DarkRed";
            stat[5] = stats.critChance.ToString() + " Critical Chance";
            stat[6] = "Magenta";
            stat[7] = stats.dodgeChance.ToString() + " Dodge Chance";
            return stat;
        }
        #endregion
    }
}
