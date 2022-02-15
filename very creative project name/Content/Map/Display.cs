using System;

namespace very_creative_project_name
{
    class Display : StartGame
    {
        #region General UI (Non-dynamic fields)
        //Creates border at bottom of the map to separate for text UI
        public void Border()
        {
            int borderLine = 44;
            Console.SetCursorPosition(0, borderLine);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('▀');
            }
        }
        #endregion

        #region UI with input
        //Draws the map from tileType in Properties - check there for defining types
        public void DrawMap(int[][] fullMap)
        {           
            for (int y = 0; y < fullMap.Length; y++)
            {
                for (int x = 0; x < fullMap[y].Length; x++)
                {
                    Console.Write(Char(prop.tileType[y][x]));
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
                edit.Colour("Red");
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                edit.Colour("Blue");
                if (lastX != x || lastY != y)
                {
                    FillLast(lastX, lastY);
                    (lastX, lastY) = (x, y);
                }
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
            else
            {
                return '?';
            }
        }
        #endregion
    }
}
