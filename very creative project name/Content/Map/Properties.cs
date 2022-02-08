using System;

namespace very_creative_project_name
{
    class Properties
    {
        //44, -5 for empty space at bottom and -1 for border
        public int[][] tileType = new int[44][];
        public Properties()
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight; y++)
                {

                }
            }
        }
    }
}
