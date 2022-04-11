namespace very_creative_project_name
{
    public class Armour : Item
    {
        public int HealthBoost { get; set; }

        public Armour()
        {

        }

        public Armour(int healthBoost, int id, string name, string desc, float weight, Type type, int amt) : base(id, name, desc, weight, type, amt)
        {
            HealthBoost = healthBoost;
        }

        public override string Display()
        {
            string item = "";
            item += base.Display();
            item += " | Increases health by: " + HealthBoost + " per stack.";
            return item;
        }

        public override string DisplayNoAmount()
        {
            string item = "";
            item += base.DisplayNoAmount();
            item += " | Increases health by: " + HealthBoost + " per stack.";
            return item;
        }
    }
}
