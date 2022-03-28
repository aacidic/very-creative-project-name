using System;

namespace very_creative_project_name
{
    class Room : Map
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int centerX { get { return x + (width / 2); } }
        public int centerY { get { return y + (height / 2); } }
        int minSize = 7;
        int maxSize = 15;

        Random r = new Random();

        public Room()
        {
            //----> if time, try to find out how to use seed to do this instead of random number! perlin
            width = 2 * r.Next(minSize, maxSize);
            height = r.Next(minSize, maxSize);
            x = r.Next(1, Console.WindowWidth - width - 6);
            y = r.Next(1, Console.WindowHeight - height - 6);
        }
    }
}
