using System;
using System.Collections.Generic;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Display
    {
        #region General UI (Non-dynamic fields)
        //Creates border at bottom of the map to separate for text UI
        public void Border()
        {
            Console.SetCursorPosition(0, 44);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('▀');
            }
        }

        public void Help()
        {
            string[] controls = new string[] { "WASD", "E", "M", "H", "ESC" };
            string[] ctrlsText = new string[] { "Move around", "Interact with objects", "Resize your map", "Open up the help menu", "Save and quit" };
            string[] icons = new string[] { "¤", "■" };
            string[] iconText = new string[] { "Loot chest", "An enemy, stay away from it!"};
            Console.SetCursorPosition(0, 6);
            Console.Write("Before you start the game, this is also a quick guide!\nIn-game you will be able to press H for a simplified version of the controls and map elements.");
            Console.SetCursorPosition(0, 8);
            for (int i = 0; i < controls.Length; i++)
            {
                Console.Write("[");
                edit.Colour("Green");
                Console.Write(controls[i]);
                edit.Colour("Blue");
                Console.Write("] " + ctrlsText[i] + " ");
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
        //Draws the map from tileType in Properties - check there for defining types
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
            //Draws border below the map after map itself
            Border();
        }

        //Draws the player from the stat position
        int lastX, lastY = 1;
        public void DrawPlayer(int x, int y)
        {
            //if check prevents movement if console is not correct size
            if (Console.WindowWidth == 200 && Console.WindowHeight == 50)
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
        }

        //Update the previous player position to return to normal
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

        //Updates enemy position on move
        public void UpdateEnemy(Point enemy, int dir, bool xDir)
        {
            if (xDir)
            {
                Console.SetCursorPosition(enemy.x + dir, enemy.y);
                Console.Write(Char(2));
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(Char(prop.tileType[enemy.y][enemy.x]));
            }
            else
            {
                Console.SetCursorPosition(enemy.x, enemy.y + dir);
                Console.Write(Char(2));
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(Char(prop.tileType[enemy.y][enemy.x]));
            }
        }

        /// <summary>
        /// Returns char based on int input - tiletype in Properties also include ID definitions
        /// Type 0 = Unwalkable space in map
        /// Type 1 = Walkable space in map
        /// Type 2 = Enemy spawn in room
        /// Type 3 = Interactable in room
        /// Type 4 = Floor exit
        /// </summary>
        /// <param name="type">Character type to return</param>
        /// <returns></returns>
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
                return '?';
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
