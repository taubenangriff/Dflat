using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.GeneralizedIntervalSystems
{
    public interface IGeneralizedIntervalSystem<TElement, TInterval> 
        where TElement : IElement 
        where TInterval : IInterval
    {
        TInterval GetInterval(TElement e1, TElement e2);

        Type IntervalType => typeof(TInterval);
        Type ElementType => typeof(TElement);
    }
}
