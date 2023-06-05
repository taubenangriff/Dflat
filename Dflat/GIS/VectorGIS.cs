using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.GIS
{
    public class VectorGIS<T> : IGIS<Vector<T>, Vector<T>> where T : struct
    {
        public Vector<T> GetInterval(Vector<T> e1, Vector<T> e2) => e2 - e1;

        public Vector<T> Transpose(Vector<T> element, Vector<T> interval) => element + interval; 
    }
}
