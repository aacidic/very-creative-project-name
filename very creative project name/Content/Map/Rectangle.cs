using System;

namespace very_creative_project_name
{
    class Room : Map
    {
        public int x;
        public int y;
        public int width;
        public int height;
        /*public int centerX { get { return x + (width / 2); } }
        public int centerY { get { return y + (height / 2); } }*/
        //Use the centers later for room connection
        public int minSize = 7;
        public int maxSize = 15;

        public Room()
        {
            //----> if time, try to find out how to use seed to do this instead of random number! perlin
            width = random.Next(minSize, maxSize);
            height = random.Next(minSize, maxSize);
            x = random.Next(1, Console.WindowWidth - width - 6);
            y = random.Next(1, Console.WindowHeight - height - 6);
        }
    }
}
