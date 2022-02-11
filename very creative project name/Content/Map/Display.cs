using System;

namespace very_creative_project_name
{
    class Display
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
            foreach (int[] row in fullMap)
            {
                foreach (int single in row)
                {
                    if (single == 0)
                    {
                        Console.Write('░');
                    }
                    else if (single == 1)
                    {
                        Console.Write(' ');
                    }
                }
            }
            Border();
        }
        public void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }
        #endregion
    }
}
