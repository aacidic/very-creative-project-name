using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name.Content.Map
{
    class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int centerX { get { return X + (width / 2); } }
        public int centerY { get { return Y + (height / 2); } }
        

        public Rectangle(int x, int y, int wid, int hei)
        {
            X = x;
            Y = y;
            width = wid;
            height = hei;
        }
    }

    class Coordinate
    {
        //TL = Top Left, BR = Bottom Right
        public int tlX, tlY, brX, brY;

        public Coordinate(int x, int y, int x2, int y2)
        {
            tlX = x;
            tlY = y;
            brX = x2;
            tlY = y2;
        }
    }
}
