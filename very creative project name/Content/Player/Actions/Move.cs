using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Move : CoreLoop
    {
        /// <summary>
        /// Main functionality for player movement, moves position based on grid and InvalidMove function below
        /// </summary>
        /// <param name="key">Key Pressed by player</param>
        /// <returns>True if player has successfully moved</returns>
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

            foreach (EnemyPoint enemy in prop.enemy)
            {
                if (enemy.x == stats.x && enemy.y == stats.y)
                {
                    stats.health -= 1;
                }
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
