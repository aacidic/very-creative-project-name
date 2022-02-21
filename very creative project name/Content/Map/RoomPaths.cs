using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class RoomPaths : Map
    {
        public void CreatePathHor(int start, int end, int pos)
        {
            for (int x = Math.Min(start, end); x <= Math.Max(start, end); x++)
            {
                prop.tileType[pos][x] = 1;
            }
        }
        public void CreatePathVer(int start, int end, int pos)
        {
            for (int y = Math.Min(start, end); y <= Math.Max(start, end); y++)
            {
                prop.tileType[y][pos] = 1;
            }
        }
    }
}
