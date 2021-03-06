using System;
using System.Collections.Generic;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class CoreLoop
    {
        //Movement: WASD
        //Interacts: E = Interact with item in room, I = Inventory, Q + arrow = Attack, H = Help
        public ConsoleKey[] movementKeys = new ConsoleKey[] { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
        public ConsoleKey[] interactKeys = new ConsoleKey[] { ConsoleKey.E, ConsoleKey.I, ConsoleKey.Q, ConsoleKey.H };
        public List<Armour> shopItems;

        /// <summary>
        /// Defines base player information before playing
        /// </summary>
        public void SetPlayer()
        {
            stats.firstLoop = false;
            inv.GetArmour();
            stats.canAttack = true;
            stats.health = 10;
            stats.maxHealth = 10;
            stats.isAlive = true;
            NewShop();
        }

        /// <summary>
        /// Called on new floors to randomise shop items
        /// </summary>
        public void NewShop()
        {
            shopItems = shop.ShopItems();
            Choice();
        }

        /// <summary>
        /// Core loop of the game, allows player movement options etc.
        /// </summary>
        public void Choice()
        {
            Console.SetCursorPosition(0, 45);
            ConsoleKeyInfo keyPressed;
            while (stats.isAlive)
            {
                //Attempts to prevent gameplay on resized window - can still crash but most cases prevents
                if (Console.WindowWidth == 200 && Console.WindowHeight == 50)
                {
                    DispStats();

                    #region Key press events
                    keyPressed = Console.ReadKey(true);

                    //Checks if the player key press is included in the movement keys
                    if (Array.Exists(movementKeys, key => key == keyPressed.Key))
                    {
                        bool moveSuccess = move.Player(keyPressed);
                        if (!moveSuccess)
                        {
                            Console.SetCursorPosition(0, 45);
                            Console.Write("You cannot move there!");
                        }
                        //Clears line 45+ of console window
                        else
                        {
                            for (int x = 0; x < 200; x++)
                            {
                                for (int y = 45; y < 49; y++)
                                {
                                    Console.SetCursorPosition(x, y);
                                    Console.Write(' ');
                                }
                            }
                        }
                    }

                    //Checks if player key press is included in interact key presses
                    if (Array.Exists(interactKeys, key => key == keyPressed.Key))
                    {
                        interact.Branch(keyPressed);
                    }
                    #endregion
                    enemy.Move();

                }
                else
                {
                    keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.M)
                    {
                        interact.Branch(keyPressed);
                    }
                }

                if (stats.health <= 0)
                {
                    stats.health = 0;
                    stats.isAlive = false;
                }
            }
        }

        /// <summary>
        /// Displays player statistics on screen
        /// </summary>
        public void DispStats()
        {
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
        }
    }
}
