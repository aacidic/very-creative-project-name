using System.Collections.Generic;

using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Map : Seed
    {
        public static List<Room> roomStorage = new List<Room>();
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

            //Sets all map-based properties to 0 before display
            prop.SetBase();

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
            
            extra.Enemy();
            extra.Loot();
            disp.DrawMap();
            extra.Player();
            extra.ExitRoom();
            disp.DrawEnemies(prop.enemy);

            //Starts gameplay sequence
            core.SetPlayer();
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
            else 
            { 
                return false; 
            }
        }
        
    }
}
