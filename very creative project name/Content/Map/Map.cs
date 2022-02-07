using System;
using System.Collections.Generic;
using TextProject;

namespace very_creative_project_name.Content.Map
{
    class Map
    {
        #region Seed Generation
        //Create random seed from tick time and multiplier
        public static Random random = new Random();
        public static int seed { get; set; }
        static int[] splitSeed { get; set; }
        public static void Seed()
        {
            char[] charSplitSeed;
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
            for (int i = 0; i < charSplitSeed.Length; i++)
            {
                int.TryParse(charSplitSeed[i].ToString(), out splitSeed[i]);
            }
            Room room = new Room();
            room.Generate();
        }
        #endregion

        #region Room Information/Generation
        public struct Room
        {
            public const int minSize = 5;
            public const int maxSize = 13;
            public int rooms { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool regenerate { get; set; }

            public void Generate()
            {
                //Rooms can be anywhere from 9 to 16 based on the 6th number in the seed 
                while (rooms < 9)
                {
                    rooms += splitSeed[5];
                    //Failsafe for if 6th seed number = 0 to prevent infinite loop
                    if (splitSeed[5] == 0) { rooms = 9; }
                }

                //Fill window with empty space characters before room generation
                StartGame.disp.EmptySpace();

                //List to store rooms
                List<Rectangle> roomStorage = new List<Rectangle>();
                Rectangle currentRect = new Rectangle(0,0,0,0);

                for (int i = 0; i < rooms; i++)
                {
                    regenerate = false;

                    //----> if time, try to find out how to use seed to do this instead of random number! perlin
                    //Generate room size and position
                    width = random.Next(minSize, maxSize);
                    height = random.Next(minSize, maxSize);

                    //Random - takes away size of room and -6 to allow for bottom of the screen
                    x = random.Next(1, Console.WindowWidth - width - 6);
                    y = random.Next(1, Console.WindowHeight - height - 6);

                    //Sets current rectangle coordinate
                    (currentRect.x, currentRect.y, currentRect.width, currentRect.height) = (x, y, width, height);

                    if (i > 0)
                    {
                        //Checks each rectangle stored so far to compare for overlap prevention
                        foreach (Rectangle rect in roomStorage)
                        {
                            bool overlap = IsOverlapping(currentRect, rect);
                            if (overlap == true)
                            {
                                regenerate = true;
                            }
                        }

                        //Makes the for loop go an extra iteration if overlap is found
                        if (regenerate) { i -= 1; }
                        else
                        {
                            roomStorage.Add(new Rectangle(currentRect.x, currentRect.y, currentRect.width, currentRect.height));
                        }
                    }
                    //Only used for first rectangle to skip checks for above
                    else if (i == 0)
                    {
                        roomStorage.Add(new Rectangle(currentRect.x, currentRect.y, currentRect.width, currentRect.height));
                    }
                    
                }

                //Use list for various stuff
                for (int i = 0; i < roomStorage.Count; i++)
                {
                    //Displays rooms on console
                    //Remove 2nd parameter for below when not debugging!
                    StartGame.disp.DrawRectangle(roomStorage[i]);
                }
                //After rectangles drawn set cursor pos to empty space
                Console.SetCursorPosition(0,26);
                Console.ReadLine();
            }

            //Overlap check - checks if rectangles are overlapping by checking corner positions
            public bool IsOverlapping(Rectangle currentRect, Rectangle priorRect)
            {
                if (currentRect.x < priorRect.x + priorRect.width &&
                    currentRect.x + currentRect.width > priorRect.x &&
                    currentRect.y < priorRect.y + priorRect.height &&
                    currentRect.y + currentRect.height > priorRect.y)
                {
                    return true;
                }
                else { return false; }
            }
        }
        #endregion
    }
}
