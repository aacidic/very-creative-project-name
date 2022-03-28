using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class ExtraGeneration : Map
    {

        /// <summary>
        /// Used to call the rest of the extra generation functions as one
        /// </summary>
        public void ExtraGenerate()
        {
            ExitRoom();
            Enemy();
            Loot();
            disp.DrawMap();
            Player();
        }
        
        /// <summary>
        /// Generates player location
        /// </summary>
        public void Player()
        {
            int[] pos = IsInRoom();
            (stats.x, stats.y) = (pos[0], pos[1]);
            disp.DrawPlayer(stats.x, stats.y);
        }
        
        /// <summary>
        /// Generates all loot positions
        /// </summary>
        public void Loot()
        {
            int[] lootRange = map.ScaleRange();
            int loot = r.Next(lootRange[0], lootRange[1]);
            for (int i = 0; i < loot; i++)
            {
                int[] pos = IsInRoom();
                prop.SetExtra(pos[0], pos[1], 3);
            }
        }

        /// <summary>
        /// Generates all enemy positions
        /// </summary>
        public void Enemy()
        {
            int[] enemyRange = map.ScaleRange();
            int enemies = r.Next(enemyRange[0], enemyRange[1]);
            for (int i = 0; i < enemies; i++)
            {
                int[] pos = IsInRoom();
                prop.enemy.Add(new Point(pos[0], pos[1], 5));
            }
        }

        /// <summary>
        /// Generates map exit location
        /// </summary>
        public void ExitRoom()
        {
            int[] pos = IsInRoom();
            prop.SetExtra(pos[0], pos[1], 4);
        }

        /// <summary>
        /// Checks positions inside a room
        /// </summary>
        /// <returns>Returns an array-based coordinate inside one of the generated rooms</returns>
        public int[] IsInRoom()
        {
            //Runs through to check if random positions are within rooms, returns one position each iteration
            bool inRoom = true;
            int x, y;
            while (inRoom)
            {
                foreach (Room room in roomStorage)
                {
                    x = r.Next(0, 200);
                    y = r.Next(0, 44);
                    if (x > room.x && x < room.x + room.width)
                    {
                        if (y > room.y && y < room.y + room.height)
                        {
                            int[] pos = new int[] { x, y };
                            inRoom = false;
                            return pos;
                        }
                    }
                }
            }
            return null;
        }
    }
}
