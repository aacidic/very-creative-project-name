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
        public void MoveX(Point pos, int i)
        {
            if (stats.x > pos.x && prop.tileType[pos.y][pos.x + 1] == 1)
            {
                prop.enemy[i].x += 1;
                disp.UpdateEnemy(pos, 1, true);
            }
            else if (stats.x < pos.x && prop.tileType[pos.y][pos.x - 1] == 1)
            {
                prop.enemy[i].x -= 1;
                disp.UpdateEnemy(pos, -1, true);
            }
        }
        public void MoveY(Point pos, int i)
        {
            if (stats.y > pos.y && prop.tileType[pos.y + 1][pos.x] == 1)
            {
                prop.enemy[i].y += 1;
                disp.UpdateEnemy(pos, 1, false);
            }
            else if (stats.y < pos.y && prop.tileType[pos.y - 1][pos.x] == 1)
            {
                prop.enemy[i].y -= 1;
                disp.UpdateEnemy(pos, -1, false);
            }
        }
    }
}
