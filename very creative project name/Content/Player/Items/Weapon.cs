namespace very_creative_project_name
{
    class Weapon : Item
    {
        public int Damage { get; set; }

        public Weapon()
        {
        }

        public Weapon(int damage, int id, string name, string desc, int weight, Type type, int amt) : base(id, name, desc, weight, type, amt)
        {
            Damage = damage;
        }

        public override string Display()
        {
            string item = "";
            item += "Damage: " + Damage;
            base.Display();
            return item;
        }
    }
    //Weapons will probably be depreciated in favour of armour and consumables.
}
