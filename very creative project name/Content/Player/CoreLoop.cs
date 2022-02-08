using System;

namespace very_creative_project_name
{
    class CoreLoop : StartGame
    {
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
                    MovePlayer move = new MovePlayer(keyPressed);
                }
                Console.SetCursorPosition(0, 46);
            }
        }
    }
}
