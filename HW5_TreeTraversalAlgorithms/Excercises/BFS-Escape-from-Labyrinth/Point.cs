using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Escape_from_Labyrinth
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public Point PreviousPoint { get; set; }

        public Point(int x, int y, string direction, Point previousPoint)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.PreviousPoint = previousPoint;
        }
    }
}
