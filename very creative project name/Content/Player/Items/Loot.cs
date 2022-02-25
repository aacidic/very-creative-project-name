using System;

namespace very_creative_project_name
{
    class Loot
    {
        Random random = new Random();
        public Loot()
        {
            int result = random.Next(0, 9);
            if (result == 0)
            {
                //give player item
            }
            else if (result >= 4)
            {
                result *= 20;
            }
        }
    }
}
