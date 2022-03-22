using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class RoomPaths
    {
        /// <summary>
        /// This is something I had to follow a roguesharp tutorial for, as I couldn't think of anything else!
        /// </summary>
        /// <see cref="https://roguesharp.wordpress.com/2016/04/03/roguesharp-v3-tutorial-connecting-rooms-with-hallways/"/>

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
                prop.tileType[y][pos + 1] = 1;
            }
        }
    }
}
