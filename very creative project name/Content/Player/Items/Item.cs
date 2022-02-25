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
        public string name;
        public int id;
        public string desc;
        public float weight;
        public int special;
        public Type type;
        public int stack;

        public Item()
        {
            
        }
        
        public Item(string name, int id, string desc, float weight, int special, Type type, int stack)
        {
            this.name = name;
            this.id = id;
            this.desc = desc;
            this.weight = weight;
            this.special = special;
            this.type = type;
            this.stack = stack;
        }

        //Don't display ID or special
        public virtual string Display()
        {
            string item = "";
            item += type.ToString() + ": ";
            item += name + " > ";
            item += desc + " > ";
            item += "Rarity: " + weight;
            item += "Amount: " + stack;
            return item;
        }
    }
}
