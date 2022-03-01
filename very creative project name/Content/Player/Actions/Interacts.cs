using System;
using static very_creative_project_name.Ref;
using System.Threading;

namespace very_creative_project_name
{
    class Interacts : CoreLoop
    {
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
            Choice();
        }

        void Resize()
        {
            Console.SetWindowSize(200, 50);
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
        }

        void OpenLoot()
        {
            Random r = new Random();
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
                stats.inventory.Add(new Armour());
                loot = "a new armour!";
            }
            else if (randomPull == 1)
            {
                stats.inventory.Add(new Weapon());
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
    }
}
