using System;
using static Cubes.Interfaces;

namespace Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two cubes
            Cube cube1 = new Cube(new Point(1, 1, 1), 4);
            Cube cube2 = new Cube(new Point(1, 1, 2), 3);

            // Print some info
            Console.WriteLine("First cube's side is {0}, centered at ({1},{2},{3}) and it's Volume is: {4}", cube1.Side, cube1.Center.X, cube1.Center.Y, cube1.Center.Z, cube1.Volume().ToString());
            Console.WriteLine("Second cube's side is {0}, centered at ({1},{2},{3}) and it's Volume is: {4}", cube2.Side, cube2.Center.X, cube2.Center.Y, cube2.Center.Z, cube2.Volume().ToString());

            // Calculate intersection box
            I3dObject intersect = Operators.CubeIntersec(cube1, cube2);

            // Print result
            Console.WriteLine("Intersection Volume is: {0}", (intersect == null) ? "0" : intersect.Volume().ToString());
        }
    }
}
