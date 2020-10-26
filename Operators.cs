using static Cubes.Interfaces;

namespace Cubes
{
    public static class Operators
    {

        // Get the intersection box formed by two overlapped Cubes
        public static I3dObject CubeIntersec (Cube cube1, Cube cube2)
        {
            // Look and fit for Max and Min cube by it's volume
            Cube maxCube = (cube1.Volume() > cube2.Volume()) ? cube1 : cube2;
            Cube minCube = (cube1.Volume() <= cube2.Volume()) ? cube1 : cube2;

            // Look for any intersection vertex, min cube based
            bool cubesIntersect = false;
            for(short i = 0; i <= 7; i++)
            {
                if(IsInside(maxCube, minCube.Vertex(i))) cubesIntersect = true;
            }

            // If cubes don't intersect, returns null
            if (cubesIntersect == false) return null;

            // Look for intersection volume
            return new Box(
                (minCube.MinDimension(Dimension.Axis.x) < maxCube.MinDimension(Dimension.Axis.x)) ? maxCube.MinDimension(Dimension.Axis.x) : minCube.MinDimension(Dimension.Axis.x),
                (minCube.MaxDimension(Dimension.Axis.x) > maxCube.MaxDimension(Dimension.Axis.x)) ? maxCube.MaxDimension(Dimension.Axis.x) : minCube.MaxDimension(Dimension.Axis.x),

                (minCube.MinDimension(Dimension.Axis.y) < maxCube.MinDimension(Dimension.Axis.y)) ? maxCube.MinDimension(Dimension.Axis.y) : minCube.MinDimension(Dimension.Axis.y),
                (minCube.MaxDimension(Dimension.Axis.y) > maxCube.MaxDimension(Dimension.Axis.y)) ? maxCube.MaxDimension(Dimension.Axis.y) : minCube.MaxDimension(Dimension.Axis.y),

                (minCube.MinDimension(Dimension.Axis.z) < maxCube.MinDimension(Dimension.Axis.z)) ? maxCube.MinDimension(Dimension.Axis.z) : minCube.MinDimension(Dimension.Axis.z),
                (minCube.MaxDimension(Dimension.Axis.z) > maxCube.MaxDimension(Dimension.Axis.z)) ? maxCube.MaxDimension(Dimension.Axis.z) : minCube.MaxDimension(Dimension.Axis.z)
                );
        }

        // Get True if the point object is inside the cube object
        public static bool IsInside (Cube cube, Point point)
        {
            if (point.X >= cube.MinDimension(Dimension.Axis.x) && point.X <= cube.MaxDimension(Dimension.Axis.x)
                && point.Y >= cube.MinDimension(Dimension.Axis.y) && point.Y <= cube.MaxDimension(Dimension.Axis.y)
                && point.Z >= cube.MinDimension(Dimension.Axis.z) && point.Z <= cube.MaxDimension(Dimension.Axis.z))
                return true;
            return false;
        }
    }
}
