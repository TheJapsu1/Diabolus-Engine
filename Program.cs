using System;

namespace Diabolus_Engine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Editor())
                game.Run();
        }
    }
}
