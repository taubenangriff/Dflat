using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dflat.GIS
{
    public static class GISExtensions
    {
        public static TInterval GetInverseInterval<TElement, TInterval>(this IGIS<TElement, TInterval> gis, TElement e1, TElement e2)
            //where TInterval : IAdditionOperators<TInterval, TInterval, TInterval>, IAdditiveIdentity<TInterval, TInterval>
        {
            return gis.GetInterval(e2, e1);
        }

        public static IGIS<TResultElement, TResultInterval> CreateQuotient<TInterval, TResultInterval, TElement, TResultElement>
            (
                this IGIS<TElement, TInterval> gis,
                ICongruence<TInterval, TResultInterval, TElement, TResultElement> congruence
            )
            //where TInterval : IAdditionOperators<TInterval, TInterval, TInterval>, IAdditiveIdentity<TInterval, TInterval>
            //where TResultInterval : IAdditionOperators<TResultInterval, TResultInterval, TResultInterval>, IAdditiveIdentity<TResultInterval, TResultInterval>
        {
            return new QuotientGIS<TInterval, TResultInterval, TElement, TResultElement>(congruence, gis);
        }
    }
}
