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
                if (InvalidMove(checkValidX, checkValidY - 1))
                {
                    stats.y -= 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.A)
            {
                if (InvalidMove(checkValidX - 1, checkValidY))
                {
                    stats.x -= 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.S)
            {
                if (InvalidMove(checkValidX, checkValidY + 1))
                {
                    stats.y += 1;
                }
                else { return false; }
            }
            else if (key.Key == ConsoleKey.D)
            {
                if (InvalidMove(checkValidX + 1, checkValidY))
                {
                    stats.x += 1;
                }
                else { return false; }
            }
            disp.DrawPlayer();
            return true;
        }

        //Checks if player is on tiletype 0 (wall gradiant char) or tiletype 2 (enemy)
        public bool InvalidMove(int x, int y)
        {
            if (prop.tileType[y][x] == 0 || prop.tileType[y][x] == 2)
            {
                return false;
            }
            return true;
        }
    }
}
