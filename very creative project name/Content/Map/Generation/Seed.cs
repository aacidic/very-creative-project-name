using System;

namespace very_creative_project_name
{
    class Seed
    {
        //Create random seed from tick time and multiplier
        public Random random = new Random();
        public static int seed;
        public static int[] splitSeed;
        public void GenSeed()
        {
            char[] charSplitSeed;
            seed = (int)DateTime.UtcNow.Ticks;
            int seedRandomizer = random.Next(-4, 4);
            //Failsafe for if below tries to divide by 0 and explode everything
            if (seedRandomizer != 0)
            {
                seed /= seedRandomizer;
            }
            //Makes seed a positive number
            if (seed < 0)
            {
                seed = seed * -1;
            }
            //Converts the int seed into individual digits, to use each part for generation
            charSplitSeed = seed.ToString().ToCharArray();
            splitSeed = new int[charSplitSeed.Length];
            for (int i = 0; i < charSplitSeed.Length; i++)
            {
                int.TryParse(charSplitSeed[i].ToString(), out splitSeed[i]);
            }
           
            Map map = new Map();
            map.Generate();
        }
    }
}
