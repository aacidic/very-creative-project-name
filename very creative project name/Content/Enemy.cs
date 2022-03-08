using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Enemy
    {
        public bool InRange(Point pos)
        {
            if ((pos.x + 30 > stats.x || pos.x - 30 > stats.x) && 
                (pos.y + 15 > stats.y || pos.y - 15 > stats.y))
            {
                return true;
            }
            return false;
        }
        public void MoveX(Point pos)
        {
            if (stats.x > pos.x && prop.tileType[pos.y][pos.x + 1] == 1)
            {
                prop.tileType[pos.y][pos.x] = 1;
                disp.UpdateEnemyX(pos.x, pos.y, 0);
                prop.tileType[pos.y][pos.x + 1] = 2;
                disp.UpdateEnemyX(pos.x, pos.y, 1);
            }
            else if (stats.x < pos.x && prop.tileType[pos.y][pos.x - 1] == 1)
            {
                prop.tileType[pos.y][pos.x] = 1;
                disp.UpdateEnemyX(pos.x, pos.y, 0);
                prop.tileType[pos.y][pos.x - 1] = 2;
                disp.UpdateEnemyX(pos.x, pos.y, -1);
            }
        }
        public void MoveY(Point pos)
        {
            if (stats.y > pos.y && prop.tileType[pos.y + 1][pos.x] == 1)
            {
                prop.tileType[pos.y][pos.x] = 1;
                disp.UpdateEnemyY(pos.x, pos.y, 0);
                prop.tileType[pos.y + 1][pos.x] = 2;
                disp.UpdateEnemyY(pos.x, pos.y, 1);
            }
            else if (stats.y < pos.y && prop.tileType[pos.y - 1][pos.x] == 1)
            {
                prop.tileType[pos.y][pos.x] = 1;
                disp.UpdateEnemyY(pos.x, pos.y, 0);
                prop.tileType[pos.y - 1][pos.x] = 2;
                disp.UpdateEnemyY(pos.x, pos.y, -1);
            }
        }
    }
}
