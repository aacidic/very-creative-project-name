using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Enemy
    {
        Random r = new Random();

        /// <summary>
        /// Iterates through all enemies, then checks range - if true then moves enemy
        /// </summary>
        public void Move()
        {
            int i = 0;
            foreach (Point pos in prop.enemy)
            {
                if (InMoveRange(pos) && !CanAttack(pos))
                {
                    //Enemy movement
                    int dir = r.Next(0, 9);
                    if (dir >= 0 && dir <= 4)
                    {
                        enemy.MoveX(pos, i, false);
                    }
                    else if (dir > 4 && dir < 9)
                    {
                        enemy.MoveY(pos, i, false);
                    }
                }

                if (CanAttack(pos))
                {

                }

                i += 1;
            }
        }
        /// <summary>
        /// Checks if enemy is within a certain range of the player
        /// </summary>
        /// <param name="pos">Enemy position</param>
        /// <returns>true if in range</returns>
        public bool InMoveRange(Point pos)
        {
            if ((pos.x + 30 > stats.x || pos.x - 30 > stats.x) && 
                (pos.y + 15 > stats.y || pos.y - 15 > stats.y))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if enemy is within attack range of player
        /// </summary>
        /// <param name="pos">Enemy position</param>
        /// <returns>true if in range</returns>
        public bool CanAttack(Point pos)
        {
            if ((pos.x + 4 > stats.x || pos.x - 4 > stats.x) &&
                 (pos.y + 2 > stats.y || pos.y - 2 > stats.y))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the position enemy is attempting to move is valid
        /// </summary>
        /// <param name="pos">Enemy[enemy] position</param>
        /// <param name="enemy">Enemy number </param>
        /// <param name="dir">Direction for setcursorposition</param>
        /// <param name="xDir">Whether the check is horizontal</param>
        /// <returns>true if enemy can move to position</returns>
        public bool ValidMove(Point pos, int enemy, int dir, bool xDir)
        {
            if (xDir)
            {
                if (prop.tileType[pos.y][pos.x + dir] == 1)
                {
                    return true;
                }
            }
            else
            {
                if (prop.tileType[pos.y + dir][pos.x] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Moves the enemy horizontally
        /// </summary>
        /// <param name="pos">enemy[i] position</param>
        /// <param name="i">The enemy number</param>
        public void MoveX(Point pos, int i, bool invert)
        {
            int dir = 0;
            if (stats.x > pos.x)
            {
                dir = 1;
            }
            else if (stats.x < pos.x)
            {
                dir = -1;
            }

            if (invert)
            {
                dir *= -1;
            }

            if (ValidMove(pos, i, dir, true))
            {
                prop.enemy[i].x += dir;
                disp.UpdateEnemy(pos, dir, true);
            }
        }
        /// <summary>
        /// Moves the enemy vertically
        /// </summary>
        /// <param name="pos">enemy[i] position</param>
        /// <param name="i">The enemy number</param>
        public void MoveY(Point pos, int i, bool invert)
        {
            int dir = 0;
            if (stats.y > pos.y)
            {
                dir = 1;
            }
            else if (stats.y < pos.y)
            {
                dir = -1;
            }

            if (invert)
            {
                dir *= -1;
            }

            if (ValidMove(pos, i, dir, false))
            {
                prop.enemy[i].y += dir;
                disp.UpdateEnemy(pos, dir, false);
            }
        }

        /// <summary>
        /// Lets the enemy attack - To be implemented!
        /// </summary>
        void Attack()
        {

        }
    }
}
