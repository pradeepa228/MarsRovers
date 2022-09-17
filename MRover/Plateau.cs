﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRover
{
    public class Plateau
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Plateau(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
            X = x;
            Y = y;
        }
    }
}