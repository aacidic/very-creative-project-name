using System;

namespace very_creative_project_name
{
    #region Seed has been depreciated - mainly due to limited knowledge of perlin noise generation at this time.
    class Seed
    {
        //Create random seed from tick time and multiplier
        public Random random = new Random();
        public int seed;
        public int[] splitSeed;
        /// <summary>
        /// Generates a seed - is currently only used for the listed functionalities below
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Seed digit[2] is used for the amount of enemies
        ///         Seed digit[3] is used for the amount of loot
        ///         Seed digit[4] influences the connected paths of the map
        ///         Seed digit[5] influences the number of rooms
        ///     </para>
        /// </remarks>
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
        }
    }
    #endregion
}
