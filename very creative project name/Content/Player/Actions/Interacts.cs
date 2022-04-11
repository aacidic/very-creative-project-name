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
            if (interact.Key == ConsoleKey.E)
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
                    Console.SetCursorPosition(0, 45);
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
        /// Short function to centralise any information that needs configuring before map is regerated
        /// </summary>
        /// <param name="increase">Increase of difficulty to be fed for new map generation</param>
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
                if (randomPull >= 0 && randomPull <= 1)
                {
                    Item item = inv.RollArmour();
                    loot = "the " + item.Name + "!";
                }
                else if (randomPull == 2)
                {
                    stats.potionsHeld += 1;
                    loot = "a health potion!";
                }
                else if (randomPull == 3)
                {
                    loot = "nothing.... it was empty!";
                }
                else if (randomPull >= 4)
                {
                    int[] goldBaseRange = map.ScaleRange();
                    int gold = randomPull * r.Next(goldBaseRange[0], goldBaseRange[1]);
                    stats.gold += gold;
                    loot = gold.ToString() + " gold!";
                }
                await Task.Delay(400);
                Console.Write("You obtained " + loot);
                //Sets loot to empty map position
                disp.UpdateTile(chestPos[0], chestPos[1], 1);
                disp.DrawPlayer();
                openingLootState = 0;
            }
            else
            {
                Console.SetCursorPosition(0, 46);
                Console.Write("You can't open the same chest twice!");
            }
        }

        /// <summary>
        /// Opens the player's inventory
        /// </summary>
        void OpenInventory()
        {
            InventoryText();

            Console.SetCursorPosition(0, 96);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            int[] itemPrices = new int[3];

            int i = 0;
            while (key.Key != ConsoleKey.I)
            {
                if (i == 0)
                {
                    #region Shop Items
                    Console.SetCursorPosition(0, 84);
                    int itemNumber = 0;
                    foreach (Armour item in core.shopItems)
                    {
                        edit.Colour("Green");
                        Console.Write("PRESS [" + (itemNumber + 1) + "] TO PURCHASE | Cost: " + inv.prices[item.ID] + " Gold | " + item.DisplayNoAmount() + "\n");
                        itemPrices[itemNumber] = inv.prices[item.ID];
                        itemNumber += 1;
                    }
                    #endregion
                }

                key = Console.ReadKey(true);

                #region Shop Functionality (2 parts, 1 to check if player is buying from shop, second half purchases from shop)
                int shopItem = 0;
                bool buyingFromShop = false;
                if (key.Key == ConsoleKey.D1)
                {
                    shopItem = 0;
                    buyingFromShop = true;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    shopItem = 1;
                    buyingFromShop = true;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    shopItem = 2;
                    buyingFromShop = true;
                }
                

                if (stats.gold > itemPrices[shopItem] && buyingFromShop)
                {
                    stats.inventory.Add(core.shopItems[shopItem]);
                    core.shopItems.RemoveAt(shopItem);
                    edit.Colour("White");
                    Console.Write("You have purchased this item! This will be updated the next time you open your inventory.");
                    buyingFromShop = false;
                }
                else if (buyingFromShop)
                {
                    Console.SetCursorPosition(0, 87);
                    edit.Colour("Red");
                    Console.WriteLine(edit.Format("You cannot afford that item!"));
                    buyingFromShop = false;
                }
                #endregion

                if (key.Key == ConsoleKey.H)
                {
                    Console.SetCursorPosition(0, 55);
                    edit.Colour("White");
                    Console.Write(edit.Format(UsePotion()));
                    DispStats();
                    Console.SetCursorPosition(0, 96);
                    InventoryText();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, 95);
                    edit.Colour("Red");
                    Console.Write(edit.Format("      Are you sure? Press ENTER to confirm the choice of Save and Quit.      "));
                    ConsoleKeyInfo confirmAction = Console.ReadKey();
                    if (confirmAction.Key == ConsoleKey.Enter)
                    {
                        save.SaveAndQuit();
                    }
                    else
                    {
                        InventoryText();
                    }
                }

                i += 1;
            }
            for (int y = 51; y < 100; y++)
            {
                for (int x = 0; x < 200; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Calculates 20% of the player's maximum health, adds that on use. Prevents health from exceeding max health.
        /// </summary>
        /// <returns>Text output of potion use result</returns>
        string UsePotion()
        {
            if (stats.potionsHeld > 0)
            {
                float fMaxHealth = stats.maxHealth;
                fMaxHealth *= 0.2f;
                stats.health += (int)MathF.Round(fMaxHealth);
                if (stats.health > stats.maxHealth)
                {
                    stats.health = stats.maxHealth;
                }
                stats.potionsHeld -= 1;
                return "You have used a health potion!";
            }
            else
            {
                return "     You have no potions!     ";
            }
        }

        /// <summary>
        /// Most standard formatted text displayed in inventory
        /// </summary>
        void InventoryText()
        {
            //Standard inventory text
            string exitInvText = "Press I again to exit your inventory and return to the game.";
            string potionText = "You current have " + stats.potionsHeld + " health potions to use.";
            string usePotionText = "Press [H] to use a potion. Potions heal you for 20% of your health.";
            string exitText = "Press ESC to save and quit the game. This can only be done in your inventory.";
            string fullLine = new string('=', 200);

            edit.Colour("White");
            Console.SetCursorPosition(0, 51);
            Console.Write(fullLine);
            Console.SetCursorPosition(0, 53);
            Console.WriteLine(edit.Format(exitInvText));
            Console.SetCursorPosition(0, 55);
            Console.WriteLine(edit.Format(potionText));
            Console.SetCursorPosition(0, 56);
            Console.WriteLine(edit.Format(usePotionText));
            Console.SetCursorPosition(0, 58);
            Console.Write(fullLine);

            //Writes items in inventory
            Console.SetCursorPosition(0, 60);
            Console.WriteLine(edit.Format("Your Items:"));
            Console.SetCursorPosition(0, 62);
            foreach (Item item in stats.inventory)
            {
                edit.Colour("White");
                Console.Write(item.Display() + "\n");
            }
            Console.SetCursorPosition(0, 80);
            Console.Write(fullLine);
            Console.SetCursorPosition(0, 82);
            Console.WriteLine(edit.Format("The Shop:"));
            Console.SetCursorPosition(0, 89);
            Console.Write(fullLine);
            edit.Colour("Red");
            Console.SetCursorPosition(0, 95);
            Console.WriteLine(edit.Format(exitText));
            edit.Colour("Blue");
        }

        /// <summary>
        /// Allows the player to attack
        /// </summary>
        async Task AttackAsync()
        {
            Console.SetCursorPosition(0, 46);
            string attackText = "Press an arrow key for your attack's direction!";
            Console.WriteLine(edit.Format(attackText));
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
                disp.DrawPlayer();

                int i = 0;
                foreach (EnemyPoint iEnemy in prop.enemy)
                {
                    if (attackPos[0] == iEnemy.x && attackPos[1] == iEnemy.y)
                    {
                        iEnemy.health -= 1;
                        if (iEnemy.health <= 0)
                        {
                            string enemyDeath = "The enemy has now perished!";
                            prop.enemy.RemoveAt(i);
                            Console.SetCursorPosition(0, 47);
                            Console.WriteLine(edit.Format(enemyDeath));
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
