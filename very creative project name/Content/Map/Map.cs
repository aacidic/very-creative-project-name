using System;
using System.Collections.Generic;

namespace very_creative_project_name.Content.Map
{
    class Map
    {
        public static Display disp = new Display();
        public static RoomConnector connect = new RoomConnector();

        #region Seed Generation
        //Create random seed from tick time and multiplier
        public static Random random = new Random();
        public static int seed { get; set; }
        static char[] charSplitSeed { get; set; }
        static int[] splitSeed { get; set; }
        public static void Seed()
        {
            seed = (int)DateTime.UtcNow.Ticks;
            float seedRandomizer = random.Next(-4, 4);
            //Failsafe for if below tries to divide by 0 and explode everything
            if (seedRandomizer != 0)
            {
                seed /= (int)seedRandomizer;
            }
            //Makes seed a positive number
            if (seed < 0)
            {
                seed = seed * -1;
            }
            //Converts the int seed into individual digits, to use each part for generation
            charSplitSeed = seed.ToString().ToCharArray();
            splitSeed = new int[charSplitSeed.Length];
            Console.WriteLine(seed);
            Room room = new Room();
            room.Generate();
        }
        #endregion

        #region Room Information/Generation
        public struct Room
        {
            public const int minSize = 5;
            public const int maxSize = 11;

            public int rooms { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int width { get; set; }
            public int height { get; set; }

            public void Generate()
            {
                for (int i = 0; i < charSplitSeed.Length; i++)
                {
                    int.TryParse(charSplitSeed[i].ToString(), out splitSeed[i]);
                }

                //Rooms can be anywhere from 9 to 16 based on the 6th number in the seed 
                while (rooms < 9)
                {
                    rooms += splitSeed[5];
                    //Failsafe for if 6th seed number = 0 to prevent infinite loop
                    if (splitSeed[5] == 0) { rooms = 9; }
                }

                //Fill window with empty space characters
                disp.EmptySpace();

                //List to store rooms
                List<Rectangle> roomStorage = new List<Rectangle>();
                for (int i = 0; i < rooms; i++)
                {
                    //Generate room size and position
                    width = random.Next(minSize, maxSize);
                    height = random.Next(minSize, maxSize);
                    //Random takes away size of room, -6 to allow for bottom of the screen
                    x = random.Next(1, Console.WindowWidth - width - 6);
                    y = random.Next(1, Console.WindowHeight - height - 6);

                    //Add room info to list
                    roomStorage.Add(new Rectangle(x, y, width, height));
                }

                //Use list for various stuff
                for (int i = 0; i < roomStorage.Count; i++)
                {
                    //Displays rooms on console
                    disp.DrawRectangle(roomStorage[i]);
                }
                Console.ReadLine();
            }
        }
        #endregion
    }
}
