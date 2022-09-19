using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MRover
{
    public class Position
    {
           public int X { get;  set; }
           public int Y { get;  set; }
           public char Direction { get;  set; }
           string StringDirection = "NEWS";

        public Position(int x, int y, char direction)
        {
            if (x < 0 || y < 0 || !StringDirection.Contains(direction))
            {
                throw new ArgumentException("Position can not have negative values or invalid direction.");
            }
            else
            {
                X = x;
                Y = y;
                Direction = direction;
            }
        }
        
    }
}