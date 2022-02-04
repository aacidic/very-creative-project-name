using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name.Content.Map
{
    class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int centerX { get { return X + (Width / 2); } }
        public int centerY { get { return Y + (Height / 2); } }
        

        public Rectangle(int x, int y, int wid, int hei)
        {
            X = x;
            Y = y;
            Width = wid;
            Height = hei;
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
