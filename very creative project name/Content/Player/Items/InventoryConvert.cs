using System.IO;
using System.Collections.Generic;
using System;

namespace very_creative_project_name
{   
    class InventoryConvert
    {
        public List<Item> inventory = new List<Item>();

        public Weapon starterWeapon;
        public Armour starterArmour;

        public InventoryConvert()
        {
            foreach (string line in File.ReadLines("ItemList.txt"))
            {
                string[] item = line.Split('|');
                //Check item type
                if (int.Parse(item[1]) == 0)
                {
                    //actually don't do this later
                    //but do it as json!!!! convert itemlist currently to json too
                }
            }
        }
    }
}
