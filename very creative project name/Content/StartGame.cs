using System;
using very_creative_project_name.Content.Map;
using very_creative_project_name.Content.Text;

namespace TextProject
{
    class StartGame
    {
        static void Main(string[] args)
        {
            ConsoleEdits edit = new ConsoleEdits();
            Console.Clear();

            edit.Title("title");
            edit.Colour("Blue");

            Console.ReadLine();
            Map.Seed();
        }
    }
}
