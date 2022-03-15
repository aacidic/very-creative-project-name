using System;
using static very_creative_project_name.Ref;
using System.Threading;

namespace very_creative_project_name
{
    class Interacts : CoreLoop
    {
        Random r = new Random();

        /// <summary>
        /// Branch for all interact keys, routes to different functions based on pressed key parsed in
        /// </summary>
        /// <param name="interact">Key pressed by player fed into branch</param>
        public void Branch(ConsoleKeyInfo interact)
        {
            if (interact.Key == ConsoleKey.M)
            {
                Resize();
            }
            else if (interact.Key == ConsoleKey.E)
            {
                if (prop.tileType[stats.y][stats.x] == 3)
                {
                    OpenLoot();
                }
                else
                {
                    Console.Write("There is nothing to open!");
                }
            }
            else if (interact.Key == ConsoleKey.I)
            {
                OpenInventory();
            }
            else if (interact.Key == ConsoleKey.H)
            {
                Console.SetCursorPosition(0, 45);
                disp.Help(true);
            }
            else if (interact.Key == ConsoleKey.Q)
            {
                Attack();
            }
            Choice();
        }

        /// <summary>
        /// Resizes the window to default on M key press
        /// </summary>
        void Resize()
        {
            Console.SetWindowSize(200, 50);
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Allows the player to open the chests within the map
        /// </summary>
        void OpenLoot()
        {
            int randomPull = r.Next(0, 10);
            string loot = "";
            Console.Write("Opening chest");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            if (randomPull == 0)
            {
                //stats.inventory.Add(new Armour());
                loot = "a new armour!";
            }
            else if (randomPull == 1)
            {
                //stats.inventory.Add(new Weapon());
                loot = "a new weapon!";
            }
            else if (randomPull >= 2)
            {
                int gold = randomPull * r.Next(1,30);
                stats.gold += gold;
                loot = gold.ToString() + " gold!";
            }
            Thread.Sleep(400);
            Console.Write("You obtained " + loot);
            //Sets loot to empty map position
            prop.tileType[stats.y][stats.x] = 1;
        }

        /// <summary>
        /// Opens the player's inventory - To be implemented!
        /// </summary>
        void OpenInventory()
        {
            Console.SetCursorPosition(0, 96);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            int i = 0;
            while (key.Key != ConsoleKey.I)
            {
                if (i == 0)
                {
                    string exitInvText = "Press I again to exit your inventory and return to the game.";
                    Console.SetCursorPosition(0, 50);
                    edit.Colour("White");
                    Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (exitInvText.Length / 2)) + "}", exitInvText));
                    edit.Colour("Blue");
                    Console.SetCursorPosition(0, 55);
                    Console.Write("consumables here");
                    Console.SetCursorPosition(0, 60);
                    Console.Write("weapon list here");
                }
                key = Console.ReadKey(true);
                i += 1;
            }
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Lets the player attack - To be implemented!
        /// </summary>
        void Attack()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow && prop.tileType[stats.y + 1][stats.x] == 1)
            {
                Console.SetCursorPosition(stats.x, stats.y - 1);
                Console.Write("║");
            }
        }
    }
}
