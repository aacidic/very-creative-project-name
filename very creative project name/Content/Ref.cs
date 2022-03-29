using System;

namespace very_creative_project_name
{
    abstract class Ref
    {
        public static Map map = new Map();
        public static Display disp = new Display();
        public static CoreLoop core = new CoreLoop();
        public static ConsoleEdits edit = new ConsoleEdits();
        public static Properties prop = new Properties();
        public static Stat stats = new Stat();
        public static Move move = new Move();
        public static Interacts interact = new Interacts();
        public static ExtraGeneration extra = new ExtraGeneration();
        public static Enemy enemy = new Enemy();
        public static Inventory inv = new Inventory();

        public static Random r = new Random();
    }
}
