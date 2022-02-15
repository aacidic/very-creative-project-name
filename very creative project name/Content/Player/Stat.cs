using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name
{
    class Stat
    {
        public int health;
        public int charge;
        public int x, y;
        
        public Stat()
        {

        }

        public Stat(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Stat(int health, int charge, int x, int y)
        {
            this.health = health;
            this.charge = charge;
            this.x = x;
            this.y = y;
        }
    }
}
