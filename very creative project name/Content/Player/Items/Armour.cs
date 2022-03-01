namespace very_creative_project_name
{
    class Armour : Item
    {
        public int HealthBoost { get; set; }

        public Armour()
        {

        }

        public Armour(int healthBoost, int id, string name, string desc, int weight, Type type, int amt) : base(id, name, desc, weight, type, amt)
        {
            HealthBoost = healthBoost;
        }

        public override string Display()
        {
            string item = "";
            item += "Health Increase: " + HealthBoost;
            base.Display();
            return item;
        }
    }
}
