using System;

namespace very_creative_project_name
{
    class Interacts : CoreLoop
    {
        public void Branch(ConsoleKeyInfo interact)
        {
            if (interact.Key == ConsoleKey.M)
            {
                Resize();
            }
            else if (interact.Key == ConsoleKey.E)
            {

            }
            Choice();
        }

        void Resize()
        {
            Console.SetWindowSize(200, 50);
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
        }
    }
}
