using System;
using static Cubes.Dimension;

namespace Cubes
{
    public class Interfaces
    {
        public interface I3dObject
        {
            double Volume();

            public Point Vertex(Int16 vertNumber);
            
            double MinDimension(Axis axis);
         
            double MaxDimension(Axis axis);
        }
    }
}
