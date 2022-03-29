using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name
{
    public enum Type
    {
        Consumable = 0,
        Armour = 1,
        Weapon = 2
    }
    abstract class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public Type ItemType { get; set; }
        public int Amount { get; set; }

        public Item()
        {
            
        }
        
        public Item(int id, string name, string desc, float weight, Type type, int amt)
        {
            ID = id;
            Name = name;
            Description = desc;
            Weight = weight;
            ItemType = type;
            Amount = amt;
        }

        public virtual string Display()
        {
            string item = "";
            item += ID.ToString();
            item += ": "+ Name + " - ";
            item += Description;
            item += " Weight: " + Weight;
            item += " Amount: " + Amount;
            return item;
        }
    }
}
