
using System;

namespace VortexGames.Core.Math
{
    [Serializable]
    public struct IVec2 : IEquatable<IVec2>
    {
        public int X;
        public int Y;

        public static IVec2 Zero { get { return new IVec2(0, 0); } }
        public static IVec2 Up { get { return new IVec2(0, 1); } }
        public static IVec2 Down { get { return new IVec2(0, -1); } }
        public static IVec2 Right { get { return new IVec2(1, 0); } }
        public static IVec2 Left { get { return new IVec2(-1, 0); } }

        public static IVec2 operator-(IVec2 dir)
        {
            return new IVec2(-dir.X, -dir.Y);
        }

        public static IVec2 operator -(IVec2 v1, IVec2 v2)
        {
            return new IVec2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static IVec2 operator +(IVec2 v1, IVec2 v2)
        {
            return new IVec2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public IVec2(int x, int y)
        {
            X = x;
            Y = y;            
        }

        public IVec2 Perp()
        {
            return new IVec2(Y, -X);
        }

        public IVec2 ClockwiseNineGridStep()
        {
            switch (X * 10 + Y)
            {
                case 10:
                    return new IVec2(1,-1);
                case 9:
                    return new IVec2(0, -1);
                case -1:
                    return new IVec2(-1,-1);
                case -11:
                    return new IVec2(-1, 0);
                case -10:
                    return new IVec2(-1, 1);
                case -9:
                    return new IVec2(0, 1);
                case 1:
                    return new IVec2(1,1);
                case 11:
                    return new IVec2(1, 0);
                default:
                    throw new Exception($"{this} is not suitable for clockwise ninegrid step");
            }
        }
        
        public IVec2 CounterClockwiseNineGridStep()
        {
            switch (X * 10 + Y)
            {
                case 10:
                    return new IVec2(1,1);
                case 11:
                    return new IVec2(0, 1);
                case 1:
                    return new IVec2(-1, 1);
                case -9:
                    return new IVec2(-1, 0);
                case -10:
                    return new IVec2(-1, -1);
                case -11:
                    return new IVec2(0, -1);
                case -1:
                    return new IVec2(1, -1);
                case 9:
                    return new IVec2(1, 0);
                default:
                    throw new Exception($"{this} is not suitable for clockwise ninegrid step");
            }
        }

        public static float SqrMagnitude(IVec2 start, IVec2 end)
        {
            return (start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is IVec2 && Equals((IVec2)obj);
        }

        public bool Equals(IVec2 other)
        {
            return X == other.X && Y == other.Y;
        }

    }
}