using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.GIS
{
    /// <summary>
    /// A product GIS of two GIS structures.
    /// </summary>
    /// <typeparam name="TE1">TElement of GIS1</typeparam>
    /// <typeparam name="TE2">TElement of GIS2</typeparam>
    /// <typeparam name="TI1">TInterval of GIS1</typeparam>
    /// <typeparam name="TI2">TInterval of GIS2</typeparam>
    public class ProductGIS<TE1, TE2, TI1, TI2> : IGIS<Tuple<TE1, TE2>, Tuple<TI1, TI2>>
    {
        IGIS<TE1, TI1> GIS1; 
        IGIS<TE2, TI2> GIS2; 

        public ProductGIS(
            IGIS<TE1, TI1> gis1,
            IGIS<TE2, TI2> gis2) 
        {
            GIS1 = gis1;
            GIS2 = gis2; 
        }
        public Tuple<TI1, TI2> GetInterval(Tuple<TE1, TE2> e1, Tuple<TE1, TE2> e2)
        {
            return Tuple.Create(
                GIS1.GetInterval(e1.Item1, e2.Item1), 
                GIS2.GetInterval(e1.Item2, e2.Item2));
        }

        public Tuple<TE1, TE2> Transpose(Tuple<TE1, TE2> element, Tuple<TI1, TI2> interval)
        {
            return Tuple.Create(
                GIS1.Transpose(element.Item1, interval.Item1),
                GIS2.Transpose(element.Item2, interval.Item2)); 
        }
    }
}
