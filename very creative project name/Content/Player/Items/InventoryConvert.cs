﻿using System.IO;
using System.Collections.Generic;
//using System.Text.Json;
using System;

namespace very_creative_project_name
{   
    class InventoryConvert
    {
        public List<Item> inventory = new List<Item>();

        Weapon starterWeapon;
        Armour starterArmour;

        string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + @"Content\Text\ItemList.txt";

        //public void ChangeToJson()
        //{
        //    foreach (string line in File.ReadLines(path))
        //    {
        //        Console.WriteLine(line);
        //        string[] item = line.Split('|');
        //        Console.WriteLine(item[0]);

        //        Weapon weapon = new Weapon
        //        {
        //            ID = int.Parse(item[0]),
        //            Name = item[1],
        //            Description = item[2],
        //            Weight = float.Parse(item[3]),
        //            ItemType = (Type)int.Parse(item[5]),
        //            Damage = int.Parse(item[6])
        //        };

        //        var json = new JsonSerializerOptions { WriteIndented = true };
        //        string jsonStr = JsonSerializer.Serialize(weapon, json);
        //        Console.WriteLine(jsonStr);
        //    }
        //}
    }
}
