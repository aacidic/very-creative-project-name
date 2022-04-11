using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Enemy
    {
        /// <summary>
        /// Iterates through all enemies, then checks range - if true then moves enemy
        /// </summary>
        public void Move()
        {
            int i = 0;
            foreach (EnemyPoint pos in prop.enemy)
            {
                int randomAction = r.Next(0, 9);
                if (InMoveRange(pos))
                {
                    if (randomAction >= 0 && randomAction <= 4)
                    {
                        enemy.MoveX(pos, i);
                    }
                    else if (randomAction > 4 && randomAction < 9)
                    {
                        enemy.MoveY(pos, i);
                    }
                }
                i += 1;
            }
        }
        /// <summary>
        /// Checks if enemy is within a certain range of the player
        /// </summary>
        /// <param name="pos">Enemy position</param>
        /// <returns>true if in range</returns>
        public bool InMoveRange(EnemyPoint pos)
        {
            if ((pos.x + 30 > stats.x || pos.x - 30 > stats.x) && 
                (pos.y + 15 > stats.y || pos.y - 15 > stats.y))
            {
                return true;
            }
            return false;
        }

        #region Depreciated Attack Check for poor functionality and on-collision hit
        /// <summary>
        /// Checks if enemy is within attack range of player
        /// </summary>
        /// <param name="pos">Enemy position</param>
        /// <returns>true if in range</returns>
        public bool CanAttack(EnemyPoint pos)
        {
            if ((pos.x + 8 > stats.x || pos.x - 8 > stats.x) &&
                 (pos.y + 4 > stats.y || pos.y - 4 > stats.y))
            {
                return true;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// Checks if the position enemy is attempting to move is valid
        /// </summary>
        /// <param name="pos">Enemy[enemy] position</param>
        /// <param name="enemy">Enemy number </param>
        /// <param name="dir">Direction for setcursorposition</param>
        /// <param name="xDir">Whether the check is horizontal</param>
        /// <returns>true if enemy can move to position</returns>
        public bool ValidMove(EnemyPoint pos, int enemy, int dir, bool xDir)
        {
            if (xDir)
            {
                if (prop.tileType[pos.y][pos.x + dir] == 1 && (stats.x != pos.x + dir || stats.y != pos.y))
                {
                    return true;
                }
            }
            else
            {
                if (prop.tileType[pos.y + dir][pos.x] == 1 && (stats.x != pos.x || stats.y != pos.y + dir))
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
        public void MoveX(EnemyPoint pos, int i)
        {
            int dir = Direction(pos, i, true);

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
        public void MoveY(EnemyPoint pos, int i)
        {
            int dir = Direction(pos, i, false);

            if (ValidMove(pos, i, dir, false))
            {
                prop.enemy[i].y += dir;
                disp.UpdateEnemy(pos, dir, false);
            }
        }

        /// <summary>
        /// Lets the enemy attack
        /// </summary>
        public void Retaliate(EnemyPoint pos, int enemy, int action)
        {
            if (action >= 0 && action <= 4)
            {
                int[] attackDisp = new int[4];

                //LEFT UP RIGHT DOWN
                attackDisp[0] = pos.x + 1;
                attackDisp[1] = pos.y + 1;
                attackDisp[2] = pos.x - 1;
                attackDisp[3] = pos.y - 1;

                _ = disp.AllDirectionAttackAsync(pos, attackDisp);
            }
        }

        /// <summary>
        /// Gets intended direction for the enemy as int
        /// </summary>
        /// <param name="pos">Enemy[i] position</param>
        /// <param name="i">The enemy number</param>
        /// <param name="xDir">Whether to check for horizontal movement or not - prevents checking the opposing direction distance</param>
        /// <returns>Direction as an int</returns>
        public int Direction(EnemyPoint pos, int i, bool xDir)
        {
            int dir = 0;
            if (xDir)
            {
                if (stats.x > pos.x)
                {
                    dir = 1;
                }
                else if (stats.x < pos.x)
                {
                    dir = -1;
                }
            }
            else
            {
                if (stats.y > pos.y)
                {
                    dir = 1;
                }
                else if (stats.y < pos.y)
                {
                    dir = -1;
                }
            }
            return dir;
        }
    }
}
