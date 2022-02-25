using System;

namespace very_creative_project_name
{
    class RoomPaths : Properties
    {
        public void CreatePathHor(int start, int end, int pos)
        {
            for (int x = Math.Min(start, end); x <= Math.Max(start, end); x++)
            {
                tileType[pos][x] = 1;
            }
        }
        public void CreatePathVer(int start, int end, int pos)
        {
            for (int y = Math.Min(start, end); y <= Math.Max(start, end); y++)
            {
                tileType[y][pos] = 1;
                tileType[y][pos + 1] = 1;
            }
        }
    }
}
