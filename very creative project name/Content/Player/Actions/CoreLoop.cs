using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class CoreLoop
    {
        //Movement: WASD
        //Interacts: M = Resize screen, E = Interact with item in room
        public ConsoleKey[] movementKeys = new ConsoleKey[] { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
        public ConsoleKey[] interactKeys = new ConsoleKey[] { ConsoleKey.E, ConsoleKey.M, ConsoleKey.I };
        Random r = new Random();

        public void Choice()
        {
            Console.SetCursorPosition(0, 45);
            bool alive = true;
            stats.health = 10;
            ConsoleKeyInfo keyPressed;

            while (alive)
            {
                //Check if an enemy is in range
                int i = 0;
                foreach (Point pos in prop.enemy)
                {
                    if (enemy.InRange(pos))
                    {
                        int dir = r.Next(0, 4);
                        if (dir == 0)
                        {
                            enemy.MoveX(pos, i);
                        }
                        else if (dir == 1)
                        {
                            enemy.MoveY(pos, i);
                        }
                    }
                    i += 1;
                }
                //Display stats at bottom line
                Console.SetCursorPosition(0, 49);
                string[] stats = disp.Stats();
                for (int split = 0; split < stats.Length; split++)
                {
                    if (split % 2 == 0)
                    {
                        edit.Colour(stats[split]);
                    }
                    else
                    {
                        Console.Write(string.Format("{0," + ((Console.WindowWidth / 5) + (stats[split].Length / 5)) + "}", stats[split]));
                    }
                }
                edit.Colour("Blue");
                Console.SetCursorPosition(0, 45);


                keyPressed = Console.ReadKey(true);

                if (Array.Exists(movementKeys, key => key == keyPressed.Key))
                {
                    bool moveSuccess = move.Player(keyPressed);
                    if (!moveSuccess)
                    {
                        Console.Write("You cannot move there!");
                    }
                    //Clears line 45 of console window if the player had a prior invalid movement
                    else
                    {
                        for (int a = 0; a < 200; a++)
                        {
                            Console.SetCursorPosition(a, 45);
                            Console.Write(' ');
                        }
                    }
                }
                else if (Array.Exists(interactKeys, key => key == keyPressed.Key))
                {
                    interact.Branch(keyPressed);
                }
                InventoryConvert inv = new InventoryConvert();
                inv.ChangeToJson();
            }
        }
    }
}
