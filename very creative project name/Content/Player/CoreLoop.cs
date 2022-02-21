using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class CoreLoop
    {
        //Movement: WASD
        //Interacts: M = Resize screen, E = Interact with item in room
        public ConsoleKey[] movementKeys = new ConsoleKey[] { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
        public ConsoleKey[] interactKeys = new ConsoleKey[] { ConsoleKey.E, ConsoleKey.M };
        public void Choice()
        {
            Console.SetCursorPosition(0, 45);
            bool alive = true;
            ConsoleKeyInfo keyPressed;
            while (alive)
            {
                keyPressed = Console.ReadKey(true);

                if (Array.Exists(movementKeys, key => key == keyPressed.Key))
                {
                    bool moveSuccess = move.Player(keyPressed);
                    if (!moveSuccess)
                    {
                        Console.Write("You cannot move there!");
                    }
                    //Clears line 45 if the player had a prior invalid movement
                    else
                    {
                        for (int i = 0; i < 200; i++)
                        {
                            Console.SetCursorPosition(i, 45);
                            Console.Write(' ');
                        }
                    }
                }
                else if (Array.Exists(interactKeys, key => key == keyPressed.Key))
                {
                    interact.Branch(keyPressed);
                }

                Console.SetCursorPosition(0, 45);
            }
        }
    }
}
