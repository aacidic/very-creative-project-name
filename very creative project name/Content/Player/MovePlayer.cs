using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name.Content.Player
{
    class MovePlayer
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MovePlayer(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W) { Y += 1; }
            else if (key.Key == ConsoleKey.A) { X -= 1; }
            else if (key.Key == ConsoleKey.S) { Y -= 1; }
            else if (key.Key == ConsoleKey.D) { X += 1; }
        }
    }
}
