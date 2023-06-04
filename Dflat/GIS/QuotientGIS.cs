using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Dflat.GIS
{
    public class QuotientGIS<TBaseInterval, TInterval, TBaseElement, TElement> : IGIS<TElement, TInterval>
    {
        ICongruence<TBaseInterval, TInterval, TBaseElement, TElement> Congruence { get; }
        IGIS<TBaseElement, TBaseInterval> BaseGIS { get; }

        public QuotientGIS(
            ICongruence<TBaseInterval, TInterval, TBaseElement, TElement> congruence,
            IGIS<TBaseElement, TBaseInterval> baseGIS)
        {
            Congruence = congruence;
            BaseGIS = baseGIS; 
        }

        public TInterval GetInterval(TElement e1, TElement e2)
        {
            var e1Cast = Congruence.GetEquivalenceClassElement(e1);
            var e2Cast = Congruence.GetEquivalenceClassElement(e2);
            return Congruence.GetCongruent(BaseGIS.GetInterval(e1Cast, e2Cast));
        }

        public TElement Transpose(TElement element, TInterval interval)
        {
            var elementCast = Congruence.GetEquivalenceClassElement(element);
            var intervalCast = Congruence.GetCongruentInverse(interval);
            return Congruence.GetEquivalenceClass(BaseGIS.Transpose(elementCast, intervalCast));
        }
    }
}
