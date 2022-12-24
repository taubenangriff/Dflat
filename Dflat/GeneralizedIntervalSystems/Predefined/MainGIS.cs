using Dflat.Intervals;
using Dflat.Pitches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.GeneralizedIntervalSystems.Predefined
{
    public static class MainGIS
    {
        public static IGeneralizedIntervalSystem<Pitch, Interval> ModalGIS = new TraditionalPitchGIS();
    }
}
