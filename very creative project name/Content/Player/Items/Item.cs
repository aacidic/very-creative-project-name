namespace very_creative_project_name
{
    public enum Type
    {
        Consumable = 0,
        Armour = 1,
        Weapon = 2
    }
    public abstract class Item
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
            if (ID < 10)
            {
                item += "0";
            }
            item += ID.ToString();
            item += " | " + Name + " - ";
            item += Description;
            item += " | You have: " + Amount + " of this item.";
            return item;
        }

        public virtual string DisplayNoAmount()
        {
            string item = "";
            if (ID < 10)
            {
                item += "0";
            }
            item += ID.ToString();
            item += " | " + Name + " - ";
            item += Description;
            return item;
        }
    }
}
