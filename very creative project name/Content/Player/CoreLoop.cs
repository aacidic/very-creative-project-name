using System;

namespace very_creative_project_name
{
    class CoreLoop : StartGame
    {
        public int x, y;
        public string[] movementKeys = new string[] { "W", "A", "S", "D" };
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
                Console.SetCursorPosition(0, 46);
            }
        }

        public void MovePlayer(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W) { y -= 1; }
            else if (key.Key == ConsoleKey.A) { x -= 1; }
            else if (key.Key == ConsoleKey.S) { y += 1; }
            else if (key.Key == ConsoleKey.D) { x += 1; }
            disp.DrawPlayer(x, y);
        }
    }
}
