namespace very_creative_project_name
{
    class Weapon : Item
    {
        public int damage;

        public Weapon(int damage, string name, int id, string desc, int weight, int special, Type type, int stack) : base(name, id, desc, weight, special, type, stack)
        {
            this.damage = damage;
        }

        public override string Display()
        {
            string item = "";
            item += "Damage: " + damage;
            base.Display();
            return item;
        }
    }
}
