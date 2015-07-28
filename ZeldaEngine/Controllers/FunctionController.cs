using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeldaEngine.Controllers
{
    public static class FunctionController
    {
        private static Random _rng = new Random();

        public static int Random(int min, int max)
        {
            return _rng.Next(min, max + 1);
        }
    }
}
