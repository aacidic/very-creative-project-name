namespace very_creative_project_name
{
    class Armour : Item
    {
        public int healthBoost;

        public Armour(int healthBoost, string name, int id, string desc, int weight, int special, Type type, int stack) : base(name, id, desc, weight, special, type, stack)
        {
            this.healthBoost = healthBoost;
        }

        public override string Display()
        {
            string item = "";
            item += "Health Increase: " + healthBoost;
            base.Display();
            return item;
        }
    }
}
