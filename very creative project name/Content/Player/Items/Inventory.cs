using System.IO;
using System.Collections.Generic;
using static very_creative_project_name.Ref;
using System;

namespace very_creative_project_name
{   
    class Inventory
    {
        public List<Armour> armours = new List<Armour>();
        public List<int> prices = new List<int>();
        string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + @"Content\Text\ItemList.txt";

        /// <summary>
        /// Gets a list of all armours listed in path ...\very creative project name\Content\Text\ItemList.txt
        /// </summary>
        public void GetArmour()
        {
            int i = 1;
            foreach (string line in File.ReadLines(path))
            {
                if (i > 1)
                {
                    string[] split = line.Split(" | ");
                    float weight = float.Parse(split[3]);
                    armours.Add(new Armour(int.Parse(split[5]), int.Parse(split[0]), split[1], split[2], weight, (Type)int.Parse(split[4]), 1));
                    prices.Add(int.Parse(split[6]) * map.ScaleRange()[0]);
                }
                i++;
            }
        }

        /// <summary>
        /// Calculated total weight from all armours in path ...\very creative project name\Content\Text\ItemList.txt
        /// </summary>
        /// <returns></returns>
        public float TotalWeight()
        {
            float weight = 0;
            foreach (Armour arm in armours)
            {
                weight += arm.Weight;
            }
            return weight;
        }

        /// <summary>
        /// Rolls armour based on weight
        /// </summary>
        /// <returns>Item player has rolled from opening chest</returns>
        public Item RollArmour()
        {
            float total = TotalWeight();
            float rolledItem = (float)Math.Round(total * r.NextDouble(), 2);
            foreach (Armour arm in armours)
            {
                rolledItem -= arm.Weight;
                if (rolledItem < 0)
                {
                    if (stats.inventory.Exists(item => item.ID == arm.ID))
                    {
                        int pos = stats.inventory.FindIndex(item => item.ID == arm.ID);
                        stats.inventory[pos].Amount += 1;
                        stats.health += arm.HealthBoost;
                        stats.maxHealth += arm.HealthBoost;
                        return arm;
                    }
                    else
                    {
                        stats.inventory.Add(arm);
                        stats.health += arm.HealthBoost;
                        stats.maxHealth += arm.HealthBoost;
                        return arm;
                    }
                }
            }
            return null;
        }
    }
}
