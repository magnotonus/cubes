using System;
using static Cubes.Dimension;
using static Cubes.Interfaces;

namespace Cubes
{
    public class Cube : I3dObject
    {
        public Point Center { get; }
        public double Side { get; }

        // Center and side values constructor
        public Cube(Point center, double side)
        {
            this.Center = center;
            this.Side = side;
        }

        // Space location constructor
        public Cube(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            // If data value is randomly entered, I put minimum values first
            if (x1 > x2) { double temp = x1; x1 = x2; x2 = temp; }
            if (y1 > y2) { double temp = y1; y1 = y2; y2 = temp; }
            if (z1 > z2) { double temp = z1; z1 = z2; z2 = temp; }

            this.Center = new Point ( x2 - x1, y2 - y1, z2 -z1 );
            this.Side = x2 - x1;
        }

        public double Volume()
        {
            return Math.Pow(Side, 3);
        }

        // Method for obtain any vertex
        public Point Vertex(Int16 vertNumber)
        {
            switch (vertNumber)
            {
                case 0 :
                    return new Point(Center.X - (Side / 2), Center.Y - (Side / 2), Center.Z - (Side / 2));
                case 1:
                    return new Point(Center.X + (Side / 2), Center.Y - (Side / 2), Center.Z - (Side / 2));
                case 2:
                    return new Point(Center.X - (Side / 2), Center.Y + (Side / 2), Center.Z - (Side / 2));
                case 3:
                    return new Point(Center.X - (Side / 2), Center.Y - (Side / 2), Center.Z + (Side / 2));
                case 4:
                    return new Point(Center.X + (Side / 2), Center.Y + (Side / 2), Center.Z - (Side / 2));
                case 5:
                    return new Point(Center.X - (Side / 2), Center.Y + (Side / 2), Center.Z + (Side / 2));
                case 6:
                    return new Point(Center.X + (Side / 2), Center.Y - (Side / 2), Center.Z + (Side / 2));
                case 7:
                    return new Point(Center.X + (Side / 2), Center.Y + (Side / 2), Center.Z + (Side / 2));
                default:
                    throw new Exception("Cubes have vertex number from 0 to 7");
            }
        }

        // Method for obtain minimal value for an axis
        public double MinDimension(Axis axis)
        {
            switch (axis)
            {
                case Axis.x:
                    return Center.X - (Side / 2);
                case Axis.y:
                    return Center.Y - (Side / 2);
                case Axis.z:
                    return Center.Z - (Side / 2);
                default:
                    throw new Exception("Not valid axis for a Cube");
            }
        }

        // Method for obtain maximal value for an axis
        public double MaxDimension(Axis axis)
        {
            switch (axis)
            {
                case Axis.x:
                    return Center.X + (Side / 2);
                case Axis.y:
                    return Center.Y + (Side / 2);
                case Axis.z:
                    return Center.Z + (Side / 2);
                default:
                    throw new Exception("Not valid axis for a Cube");
            }
        }
    }
}
