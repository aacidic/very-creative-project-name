using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name
{
    public enum Type
    {
        Weapon = 0,
        Armour = 1,
        Consumable = 2
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

        //Don't display ID or special
        public virtual string Display()
        {
            string item = "";
            item += ItemType.ToString() + ": ";
            item += Name + " > ";
            item += Description + " > ";
            item += "Rarity: " + Weight;
            item += "Amount: " + Amount;
            return item;
        }
    }
}
