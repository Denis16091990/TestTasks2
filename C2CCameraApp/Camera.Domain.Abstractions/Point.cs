using System;
using System.Collections.Generic;
using System.Text;

namespace Camera.Domain.Abstractions
{
    public struct Point : IEquatable<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                return Equals(obj);
            }
            return false;
        }

        public bool Equals(Point other)
        {
            return other.X == X && other.Y == Y && other.Z == Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}
