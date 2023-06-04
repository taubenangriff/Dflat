using System.Numerics;

namespace Dflat.GIS
{
    public interface IGIS<TElement, TInterval> 
    {
        TInterval GetInterval(TElement e1, TElement e2);
        TElement Transpose(TElement element, TInterval interval);
    }
}
