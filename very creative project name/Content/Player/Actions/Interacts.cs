using System;
using static very_creative_project_name.Ref;
using System.Threading.Tasks;

namespace very_creative_project_name
{
    class Interacts : CoreLoop
    {
        int openingLootState = 0;

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
                    openingLootState += 1;
                    _ = OpenLootAsync();
                }
                else if (prop.tileType[stats.y][stats.x] == 4)
                {
                    Console.SetCursorPosition(0, 45);
                    if (prop.enemy.Count == 0)
                    {
                        Console.Write("Are you sure you want to exit this floor? Press E to confirm.");
                        ExitFloor(0);
                    }
                    else
                    {
                        Console.Write("You wish to leave without eliminating your foes? You will have a harder time next floor...");
                        ExitFloor(1);
                    }
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
                if (stats.canAttack)
                {
                    _ = AttackAsync();
                }
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

        void ExitFloor(int increase)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.E)
            {
                Console.SetCursorPosition(0, 46);
                Console.Write("Very well.");
            }
            else
            {
                Console.Clear();
                prop.enemy.Clear();
                map.GenNew(increase);
            }
        }

        /// <summary>
        /// Allows the player to open the chests within the map
        /// </summary>
        async Task OpenLootAsync()
        {
            if (openingLootState == 1)
            {
                int[] chestPos = new int[2] { stats.x, stats.y };
                int randomPull = r.Next(0, 10);
                string loot = "";
                Console.Write("Opening chest");
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(i + "Opening Chest".Length, 45);
                    Console.Write(".");
                    await Task.Delay(200);
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
                    int gold = randomPull * r.Next(1, 30);
                    stats.gold += gold;
                    loot = gold.ToString() + " gold!";
                }
                await Task.Delay(400);
                Console.Write("You obtained " + loot);
                //Sets loot to empty map position
                disp.UpdateTile(chestPos[0], chestPos[1], 1);
                openingLootState = 0;
            }
            else
            {
                Console.SetCursorPosition(0, 46);
                Console.Write("You can't open the same chest twice!");
            }
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
                    Console.Write("weapon list here {0}", stats.difficulty);
                }
                key = Console.ReadKey(true);
                i += 1;
            }
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Allows the player to attack
        /// </summary>
        async Task AttackAsync()
        {
            Console.SetCursorPosition(0, 46);
            string attackText = "Press an arrow key for your attack's direction!";
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (attackText.Length / 2)) + "}", attackText));
            ConsoleKeyInfo key = Console.ReadKey(true);
            int[] attackPos = AttackPosition(key.Key);
            bool xDir = false;
            if (attackPos[2] == 1)
            {
                xDir = true;
            }

            //Prevents execution of display if position = 0
            if (attackPos[0] != 0 && attackPos[1] != 0)
            {
                stats.canAttack = false;
                if (xDir)
                {
                    Console.SetCursorPosition(attackPos[0], attackPos[1]);
                    Console.Write("═");
                }
                else
                {
                    Console.SetCursorPosition(attackPos[0], attackPos[1]);
                    Console.Write("║");
                }
                await Task.Delay(400);
                Console.SetCursorPosition(attackPos[0], attackPos[1]);
                Console.Write(" ");
                disp.DrawPlayer(stats.x, stats.y);

                int i = 0;
                foreach (Point iEnemy in prop.enemy)
                {
                    if (attackPos[0] == iEnemy.x && attackPos[1] == iEnemy.y)
                    {
                        iEnemy.health -= 1;
                        if (iEnemy.health <= 0)
                        {
                            string enemyDeath = "The enemy has now perished!";
                            prop.enemy.RemoveAt(i);
                            Console.SetCursorPosition(0, 47);
                            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (enemyDeath.Length / 2)) + "}", enemyDeath));
                            stats.canAttack = true;
                        }
                        else
                        {
                            disp.EnemyHealth(iEnemy.health);
                            disp.UpdateEnemy(iEnemy, 0, false);
                            int randomAction = r.Next(0, 7);
                            enemy.Retaliate(iEnemy, i, randomAction);
                        }
                    }
                    i++;
                }
            }
            _ = Task.Delay(200);
            stats.canAttack = true;
            DispStats();
        }

        /// <summary>
        /// Gets the position of the player to render an attack in the given direction
        /// </summary>
        /// <param name="key">Key pressed by player - returns 0 if key is not an arrow key</param>
        /// <returns>Returns [0],[1] as player positions, [2] is converted to bool to check direction for display</returns>
        public int[] AttackPosition(ConsoleKey key)
        {
            int[] pos = new int[3];

            if (key == ConsoleKey.UpArrow && prop.tileType[stats.y - 1][stats.x] == 1)
            {
                (pos[0], pos[1]) = (stats.x, stats.y - 1);
                pos[2] = 0;
            }
            else if (key == ConsoleKey.LeftArrow && prop.tileType[stats.y][stats.x - 1] == 1)
            {
                (pos[0], pos[1]) = (stats.x - 1, stats.y);
                pos[2] = 1;
            }
            else if (key == ConsoleKey.DownArrow && prop.tileType[stats.y + 1][stats.x] == 1)
            {
                (pos[0], pos[1]) = (stats.x, stats.y + 1);
                pos[2] = 0;
            }
            else if (key == ConsoleKey.RightArrow && prop.tileType[stats.y][stats.x + 1] == 1)
            {
                (pos[0], pos[1]) = (stats.x + 1, stats.y);
                pos[2] = 1;
            }

            return pos;
        }
    }
}
