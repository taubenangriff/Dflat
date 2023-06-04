using System.Numerics;

namespace Dflat.GIS
{
    public class NumericGIS<T> : IGIS<T, T> where T : INumberBase<T>
    {
        public T GetInterval(T e1, T e2) => e2 - e1;
        public T Transpose(T element, T interval) => element + interval;
    }

    public class IntegerGIS : NumericGIS<int> { }

    public class FloatGIS : NumericGIS<float> { }

    public class ComplexGIS : NumericGIS<Complex> { }
}
