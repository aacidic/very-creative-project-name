using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Move : CoreLoop
    {
        public bool Player(ConsoleKeyInfo key)
        {
            int checkValidY = stats.y;
            int checkValidX = stats.x;

            if (key.Key == ConsoleKey.W)
            {
                if (prop.tileType[checkValidY -= 1][stats.x] != 0)
                {
                    stats.y -= 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.A)
            {
                if (prop.tileType[stats.y][checkValidX -= 1] != 0)
                {
                    stats.x -= 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.S)
            {
                if (prop.tileType[checkValidY += 1][stats.x] != 0)
                {
                    stats.y += 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.D)
            {
                if (prop.tileType[stats.y][checkValidX += 1] != 0)
                {
                    stats.x += 1;
                }
                else { return false; }
            }
            disp.DrawPlayer(stats.x, stats.y);
            return true;
        }
    }
}
