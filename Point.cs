namespace Cubes
{
    public class Point
    {
        // Defines a basic point in space
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point (double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
