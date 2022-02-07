using System;

namespace very_creative_project_name.Content.Map
{
    class Display
    {
        #region General UI (Non-dynamic fields)
        //Sets out of bounds locations with fillChar
        public void EmptySpace()
        {
            string fillChar = "░";
            for (int i = 0; i < Console.WindowHeight - 5; i++)
            {
                string line = string.Empty;
                for (int ii = 0; ii < Console.WindowWidth; ii++)
                {
                    line += fillChar;
                }
                Console.SetCursorPosition(0, i);
                Console.Write(line);
                Border();
            }
        }
        
        //Creates border at bottom of the map to separate for text UI
        public void Border()
        {
            int borderLine = Console.WindowHeight - 5;
            Console.SetCursorPosition(0, borderLine);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('▀');
            }
        }
        #endregion

        #region UI with input
        //Draws a room as an empty character/space
        public void DrawRectangle(Rectangle rect)
        {
            Console.SetCursorPosition(rect.x, rect.y);
            //Use below for debugging, add int a to void
            //ConsoleColor[] colours = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            //Console.ForegroundColor = colours[a];
            
            for (int i = rect.y; i < rect.y + rect.height; i++)
            {
                for (int ii = rect.x; ii < rect.x + rect.width; ii++)
                {
                    //Change character in Write when used to debug
                    Console.SetCursorPosition(ii, i);
                    Console.Write(' ');
                }
            }
        }

        public void DrawPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("X");
        }
        #endregion
    }
}
