using System.IO;
using System.Collections.Generic;
using static very_creative_project_name.Ref;
using System;

namespace very_creative_project_name
{   
    class Inventory
    {
        public List<Armour> armours = new List<Armour>();
        string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + @"Content\Text\ItemList.txt";

        public void GetArmour()
        {
            Armour armour = new Armour();
            int i = 1;
            foreach (string line in File.ReadLines(path))
            {
                if (i > 1)
                {
                    string[] split = line.Split(" | ");
                    float weight = float.Parse(split[3]);
                    armours.Add(new Armour(int.Parse(split[5]), int.Parse(split[0]), split[1], split[2], weight, (Type)int.Parse(split[4]), 1));
                }
                i++;
            }
        }

        public float TotalWeight()
        {
            float weight = 0;
            foreach (Armour arm in armours)
            {
                weight += arm.Weight;
            }
            return weight;
        }
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
                    }
                    else
                    {
                        stats.inventory.Add(arm);
                        return arm;
                    }
                }
            }
            return null;
        }

        public int GetPotions()
        {
            int amount = 0;
            if (stats.inventory.Exists(item => item.ID == 00))
            {
                return amount;
            }
            else
            {
                return 0;
            }
        }
    }
}
