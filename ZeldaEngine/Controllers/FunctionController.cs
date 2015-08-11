﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace ZeldaEngine.Controllers
{
    public static class FunctionController
    {
        private static Random _rng = new Random();

        public static int Random(int min, int max)
        {
            return _rng.Next(min, max + 1);
        }

        public static double Distance(Vector2 positionOne, Vector2 positionTwo)
        {
            var x = Math.Pow(positionOne.X - positionTwo.X, 2);
            var y = Math.Pow(positionOne.Y - positionTwo.Y, 2);
            return Math.Sqrt(x + y);
        }
    }
}
