using System;

namespace Spatial_Invasor
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SpatialInvasor())
                game.Run();
        }
    }
}
