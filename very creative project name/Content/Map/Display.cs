﻿using System;
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
        public void DrawMap(int[][] fullMap)
        {           
            for (int y = 0; y < fullMap.Length; y++)
            {
                for (int x = 0; x < fullMap[y].Length; x++)
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
            //Prevents movement if console is not correct size
            if (Console.WindowWidth == 200 && Console.WindowHeight == 50)
            {
                edit.Colour("Green");
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                edit.Colour("Blue");
                if (lastX != x || lastY != y)
                {
                    FillLast(lastX, lastY);
                    (lastX, lastY) = (x, y);
                }
                Console.SetCursorPosition(0, 0);
            }
        }

        public void FillLast(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Char(prop.tileType[y][x]));
        }

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

        public void UpdateEnemyX(int x, int y, int dir)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Char(prop.tileType[y][x]));
            Console.SetCursorPosition(x + dir, y);
            Console.Write(Char(prop.tileType[y][x + dir]));
        }
        public void UpdateEnemyY(int x, int y, int dir)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Char(prop.tileType[y][x]));
            Console.SetCursorPosition(x, y + dir);
            Console.Write(Char(prop.tileType[y + dir][x]));
        }

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
