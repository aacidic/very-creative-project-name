using System;
using System.Collections.Generic;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Map : StartGame
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
            Rooms room = new Rooms();
            room.Generate();
        }
        #endregion

        #region Room Generation

        public static List<Room> roomStorage = new List<Room>();
        public struct Rooms
        {
            public int rooms;
            public bool regenerate;

            public void Generate()
            {
                //Rooms can be anywhere from 9 to 16 based on the 6th number in the seed 
                while (rooms < 9)
                {
                    rooms += splitSeed[5];
                    //Failsafe for if 6th seed number = 0 to prevent infinite loop
                    if (splitSeed[5] == 0) { rooms = 9; }
                }

                Room currentRoom;
                for (int i = 0; i < rooms; i++)
                {
                    regenerate = false;
                    currentRoom = new Room();

                    if (i > 0)
                    {
                        //Checks each rectangle stored so far to compare with current for overlap prevention
                        foreach (Room room in roomStorage)
                        {
                            bool overlap = IsOverlapping(currentRoom, room);
                            if (overlap == true) { regenerate = true; }
                        }

                        //Makes the for loop go an extra iteration if overlap is found
                        if (regenerate) { i -= 1; }
                        else { roomStorage.Add(currentRoom); }
                    }
                    //Only used for first rectangle to skip checks for above
                    else if (i == 0)
                    {
                        roomStorage.Add(currentRoom);
                    }                
                }

                //Sets all map-based properties to 0 before display
                prop.SetBase();
                RoomPaths path = new RoomPaths();

                //Sets properties at rectangle positions
                for (int i = 0; i < roomStorage.Count; i++)
                {
                    //These uses the centerX/Y of each room to create pathways between each room
                    if (i > 0)
                    {
                        int currentCenterX, currentCenterY, priorCenterX, priorCenterY;
                        (currentCenterX, currentCenterY) = (roomStorage[i].centerX, roomStorage[i].centerY);
                        (priorCenterX, priorCenterY) = (roomStorage[i - 1].centerX, roomStorage[i - 1].centerY);

                        if (splitSeed[4] > 5)
                        {
                            path.CreatePathHor(priorCenterX, currentCenterX, priorCenterY);
                            path.CreatePathVer(priorCenterY, currentCenterY, currentCenterX);
                        }
                        else
                        {
                            path.CreatePathVer(priorCenterY, currentCenterY, currentCenterX);
                            path.CreatePathHor(priorCenterX, currentCenterX, priorCenterY);
                        }
                    }
                    prop.SetRoom(roomStorage[i]);
                }

                disp.DrawMap(prop.tileType);

                //Generate player spawnpoint
                bool generatePlayer = true;
                int x, y;
                while (generatePlayer)
                {
                    x = random.Next(0, 200);
                    y = random.Next(0, 44);

                    foreach (Room room in roomStorage)
                    {
                        if (x > room.x && x < room.x + room.width)
                        {
                            if (y > room.y && y < room.y + room.height)
                            {
                                generatePlayer = false;
                                (stats.x, stats.y) = (x, y);
                                disp.DrawPlayer(stats.x, stats.y);
                                break;
                            }
                        }
                    }
                }

                //Starts gameplay sequence
                core.Choice();
            }

            //Overlap check - checks if rectangles are overlapping by checking corner positions
            public bool IsOverlapping(Room current, Room prior)
            {
                if (current.x < prior.x + prior.width &&
                    current.x + current.width > prior.x &&
                    current.y < prior.y + prior.height &&
                    current.y + current.height > prior.y)
                {
                    return true;
                }
                else { return false; }
            }
        }
        #endregion
    }
}
