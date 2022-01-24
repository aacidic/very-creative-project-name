using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name.Content.Map
{
    class Display
    {
        public void EmptySpace()
        {
            string fillChar = "░";
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                string line = string.Empty;
                for (int ii = 0; ii < Console.WindowWidth; ii++)
                {
                    line += fillChar;
                }
                Console.SetCursorPosition(0, i);
                Console.Write(line);
            }
        }

        public void DrawRectangle(Rectangle rect)
        {
            Console.SetCursorPosition(rect.X, rect.Y);

            for (int i = rect.Y; i < rect.Y + rect.height; i++)
            {
                for (int ii = rect.X; ii < rect.X + rect.width; ii++)
                {
                    Console.SetCursorPosition(ii, i);
                    Console.Write(' ');
                }
            }
        }
    }
}
