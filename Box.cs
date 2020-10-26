using System;
using static Cubes.Interfaces;

namespace Cubes
{
    class Box : I3dObject
    {
        public Point Center { get; }

        public double X1 { get; }
        public double X2 { get; }
        public double Y1 { get; }
        public double Y2 { get; }
        public double Z1 { get; }
        public double Z2 { get; }

        // Space location constructor
        public Box(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            // If data value is randomly entered, I put minimum values first
            if (x1 > x2) { double temp = x1; x1 = x2; x2 = temp; }
            if (y1 > y2) { double temp = y1; y1 = y2; y2 = temp; }
            if (z1 > z2) { double temp = z1; z1 = z2; z2 = temp; }

            this.Center = new Point(x2 - x1, y2 - y1, z2 - z1);
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Z1 = z1;
            this.Z2 = z2;
        }

        public double MaxDimension(Dimension.Axis axis)
        {
            throw new NotImplementedException();
        }

        public double MinDimension(Dimension.Axis axis)
        {
            throw new NotImplementedException();
        }

        public Point Vertex(short vertNumber)
        {
            throw new NotImplementedException();
        }

        public double Volume()
        {
            return (X2 - X1) * (Y2 - Y1) * (Z2 - Z1);
        }
    }
}