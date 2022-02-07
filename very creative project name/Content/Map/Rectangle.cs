using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name.Content.Map
{
    class Rectangle
    {
        public int x;
        public int y;
        public int width;
        public int height;
        /*public int centerX { get { return x + (width / 2); } }
        public int centerY { get { return y + (height / 2); } }*/

        public Rectangle(int x, int y, int wid, int hei)
        {
            this.x = x;
            this.y = y;
            width = wid;
            height = hei;
        }
        //move random function into here
    }
}
