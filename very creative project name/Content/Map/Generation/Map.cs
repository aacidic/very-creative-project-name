using System;
using System.Collections.Generic;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Map
    {
        public static List<Room> roomStorage = new List<Room>();
        public int rooms;
        public bool regenerate;

        /// <summary>
        /// Main function for generating the map layout
        /// </summary>
        public void Generate()
        {
            //Sets all map-based properties to 0 before display
            prop.SetBase();

            rooms = r.Next(9, 16);
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
                    if (regenerate) 
                    { 
                        i -= 1; 
                    }
                    else 
                    { 
                        roomStorage.Add(currentRoom); 
                    }
                }
                //Only used for first rectangle to skip checks for above
                else if (i == 0)
                {
                    roomStorage.Add(currentRoom);
                }                
            }

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

                    if (r.Next(0, 2) < 1)
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

            extra.ExtraGenerate();
            disp.DrawEnemies(prop.enemy);
            roomStorage.Clear();

            if (stats.firstLoop == true)
            {
                //Starts gameplay sequence
                core.SetPlayer();
            }
            else
            {
                core.NewShop();
            }
        }

        /// <summary>
        /// Is only called for generating a new map, this also increases the difficulty linearly
        /// </summary>
        public void GenNew(int additionalIncrease)
        {
            core.shopItems.Clear();
            stats.difficulty += 1 + additionalIncrease;
            map.Generate();
        }

        /// <summary>
        /// Generates two numbers which is used for generation range - default range value = 3 .. 5
        /// </summary>
        /// <returns>Scaling range 1.2 ^ difficulty</returns>
        public int[] ScaleRange()
        {
            int[] range = new int[2] { 3, 5 };
            double doubleRangeScale = Math.Pow(1.2, stats.difficulty);
            int rangeScale = (int)Math.Ceiling(doubleRangeScale);
            range[0] += rangeScale;
            range[1] += rangeScale;
            return range;
        }

        /// <summary>
        /// Overlap check - checks if rectangles are overlapping by checking corner positions
        /// </summary>
        /// <param name="current">Current room information</param>
        /// <param name="prior">Previous room information</param>
        /// <returns></returns>
        public bool IsOverlapping(Room current, Room prior)
        {
            if (current.x < prior.x + prior.width &&
                current.x + current.width > prior.x &&
                current.y < prior.y + prior.height &&
                current.y + current.height > prior.y)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
        
    }
}
