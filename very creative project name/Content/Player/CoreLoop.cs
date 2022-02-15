using System;

namespace very_creative_project_name
{
    class CoreLoop : StartGame
    {
        public string[] movementKeys = new string[] { "W", "A", "S", "D" };
        public ConsoleKey resizeKey = ConsoleKey.M;
        public string[] interactKeys = new string[] { "E" };
        public void Choice()
        {
            //Set position to empty space
            Console.SetCursorPosition(0, 46);
            bool alive = true;
            ConsoleKeyInfo keyPressed;
            while (alive)
            {
                keyPressed = Console.ReadKey();
                if (Array.Exists(movementKeys, key => key == keyPressed.Key.ToString()))
                {
                    MovePlayer(keyPressed);
                }
                else if (keyPressed.Key == resizeKey)
                {
                    Console.SetWindowSize(200, 50);
                    Console.SetWindowPosition(0, 0);
                }
                Console.SetCursorPosition(0, 46);
            }
        }

        public void MovePlayer(ConsoleKeyInfo key)
        {
            int checkValidY = stats.y;
            int checkValidX = stats.x;

            if (key.Key == ConsoleKey.W)
            {
                if (prop.tileType[checkValidY -= 1][stats.x] != 0)
                {
                    stats.y -= 1;
                }
            }
            else if (key.Key == ConsoleKey.A)
            {
                if (prop.tileType[stats.y][checkValidX -= 1] != 0)
                {
                    stats.x -= 1;
                }
            }
            else if (key.Key == ConsoleKey.S)
            {
                if (prop.tileType[checkValidY += 1][stats.x] != 0)
                {
                    stats.y += 1;
                }
            }
            else if (key.Key == ConsoleKey.D)
            {
                if (prop.tileType[stats.y][checkValidX += 1] != 0)
                {
                    stats.x += 1;
                }
            }
            disp.DrawPlayer(stats.x, stats.y);
        }
    }
}
