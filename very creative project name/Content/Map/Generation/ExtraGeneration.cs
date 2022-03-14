using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class ExtraGeneration : Map
    {
        public void Player()
        {
            int[] pos = IsInRoom();
            (stats.x, stats.y) = (pos[0], pos[1]);
            disp.DrawPlayer(stats.x, stats.y);
        }
        
        public void Loot()
        {
            if (splitSeed[3] > 0)
            {
                for (int i = 0; i < splitSeed[3]; i++)
                {
                    int[] pos = IsInRoom();
                    prop.SetExtra(pos[0], pos[1], 3);
                }
            }
        }

        public void Enemy()
        {
            if (splitSeed[2] > 0)
            {
                for (int i = 0; i < splitSeed[2]; i++)
                {
                    int[] pos = IsInRoom();
                    prop.enemy.Add(new Point(pos[0], pos[1]));
                }
            }
        }

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
                    x = random.Next(0, 200);
                    y = random.Next(0, 44);
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
