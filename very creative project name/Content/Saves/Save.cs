using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class Save
    {
        Data playerData;

        /// <summary>
        /// Serialises all player data to xml and quits the game.
        /// </summary>
        public void SaveAndQuit()
        {
            Console.SetCursorPosition(0, 149);
            int createdCounter = 1;
            #region Converts tiletype to string for easier saving
            for (int y = 0; y < 44; y++)
            {
                for (int x = 0; x < 200; x++)
                {
                    prop.mapString[y] += prop.tileType[y][x].ToString();
                }
            }
            #endregion
            try
            {
                for (int i = 1; i < 4; i++)
                {
                    
                    string path = FilePath(i);
                    
                    if (!File.Exists(path))
                    {
                        SerializeData(i);
                        break;
                    }
                    else if (createdCounter >= 3)
                    {
                        bool choosingOverride = true;
                        while (choosingOverride)
                        {
                            Console.WriteLine("All save slots are currently in use. Please type the number of and enter a save file to override. Type 0 to clear this save file.");
                            //DisplayData();
                            string strOverrideFile = Console.ReadLine();
                            if (int.TryParse(strOverrideFile, out int overrideFile) && overrideFile >= 1 && overrideFile <= 3)
                            {
                                SerializeData(overrideFile);
                                createdCounter = overrideFile - 1;
                                break;
                            }
                            else if (overrideFile == 0)
                            {
                                choosingOverride = false;
                                break;
                            }
                        }

                    }
                    createdCounter += 1;
                }
                Console.Write("Your data was saved! To load your data on your next play, type and enter this number: " + createdCounter);
                Environment.Exit(0);
            }
            catch (Exception error)
            {
                Console.WriteLine("Your data was unable to be saved: " + error.Message);
            }
        }

        /// <summary>
        /// Loads the data by deserializing and uses a number to determine the file
        /// </summary>
        public void LoadData()
        {
            Player player = new Player();
            int occupiedFiles = 3;
            for (int i = 1; i < 4; i++)
            {
                string path = FilePath(i);
                if (!File.Exists(path))
                {
                    occupiedFiles -= 1;
                }
            }

            if (occupiedFiles == 0)
            {
                player.Create();
            }
            else
            {
                Console.WriteLine("There have been saves already detected on this system, type and enter your save number, or type 0 to start a new game.");
                //DisplayData();
                bool selectingFile = true;
                while (selectingFile)
                {
                    string strFileLoaded = Console.ReadLine();
                    if (int.TryParse(strFileLoaded, out int loadFile) && loadFile >= 1 && loadFile <= 3)
                    {
                        DeserializeData(loadFile);
                        Console.CursorVisible = false;
                        Console.SetWindowSize(200, 50);
                        Console.Clear();
                        inv.GetArmour();
                        prop.SetBase();
                        prop.ConvertMap();
                        disp.DrawMap();
                        disp.DrawEnemies(prop.enemy);
                        disp.DrawPlayer();
                        core.Choice();
                    }
                    else if (loadFile == 0)
                    {
                        player.Create();
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a save file exists currently
        /// </summary>
        /// <returns>False if none exist</returns>
        public bool DoesSaveExist()
        {
            bool fileExists = false;
            for (int i = 1; i < 4; i++)
            {
                string path = FilePath(i);
                if (File.Exists(path))
                {
                    fileExists = true;
                }
            }
            return fileExists;
        }

        /// <summary>
        /// Gets the file path
        /// </summary>
        /// <param name="number">Number of file</param>
        /// <returns>File path</returns>
        public string FilePath(int number)
        {
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + @"Content\Saves\Player" + number + "Data.xml";
        }

        //public void DisplayData()
        //{
        //    for (int readXML = 1; readXML < 4; readXML++)
        //    {
        //        if (File.Exists(FilePath(readXML)))
        //        {
        //            XmlSerializer read = new XmlSerializer(typeof(Data));
        //            XmlReader reader = XmlReader.Create(FilePath(readXML));
        //            Data data = (Data)read.Deserialize(reader);
        //            Console.Write("{4}: Player {0} saved on {1} and has {2} health, and {3} gold.\n", data.savedStats.playerName, data.savedTime.ToString(), data.savedStats.health, data.savedStats.gold, readXML);                   
        //            reader.Close();
        //            SerializeData(readXML);
        //        }
        //    }
        //}
        //would have displayed saves before loading them or for overriding, but keeps corrupting data instead :(

        /// <summary>
        /// Serializes data
        /// </summary>
        /// <param name="fileToWrite">Number of file</param>
        void SerializeData(int fileToWrite)
        {
            playerData = new Data();
            XmlSerializer write = new XmlSerializer(typeof(Data));
            FileStream file = File.Create(FilePath(fileToWrite));
            write.Serialize(file, playerData);
            file.Close();
        }

        /// <summary>
        /// Deserializes data
        /// </summary>
        /// <param name="fileToOpen">Number of file</param>
        void DeserializeData(int fileToOpen)
        {
            try
            {
                XmlSerializer read = new XmlSerializer(typeof(Data));
                Data data;
                using (XmlReader reader = XmlReader.Create(FilePath(fileToOpen)))
                {
                    data = (Data)read.Deserialize(reader);
                }
                stats = data.savedStats;
                prop.enemy = data.savedEnemies;
                prop.mapString = data.savedMap;
                core.shopItems = data.savedShopItems;
            }
            catch (XmlException error)
            {
                Console.WriteLine("Unable to deserialize file: " + error.Message);
            }
        }



    }

    /// <summary>
    /// Class used for storing all data
    /// </summary>
    public class Data
    {
        public DateTime savedTime = DateTime.Now;
        public Stat savedStats = stats;
        public List<EnemyPoint> savedEnemies = prop.enemy;
        public List<Armour> savedShopItems = core.shopItems;
        public string[] savedMap = prop.mapString;
    }

    /// <summary>
    /// Only used for console displayed data for selecting files.
    /// </summary>
    public class DisplayedData
    {
        public string name;
        public DateTime timeSaved;
        public int health;
        public int gold;
    }
}
