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
                if (ValidMove(checkValidX, checkValidY - 1))
                {
                    stats.y -= 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.A)
            {
                if (ValidMove(checkValidX - 1, checkValidY))
                {
                    stats.x -= 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.S)
            {
                if (ValidMove(checkValidX, checkValidY + 1))
                {
                    stats.y += 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.D)
            {
                if (ValidMove(checkValidX + 1, checkValidY))
                {
                    stats.x += 1;
                }
                else { return false; }
            }
            disp.DrawPlayer(stats.x, stats.y);
            return true;
        }

        public bool ValidMove(int x, int y)
        {
            if (prop.tileType[y][x] == 1)
            {
                return true;
            }
            return false;
        }
    }
}
