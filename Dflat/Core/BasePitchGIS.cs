using Dflat.GIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dflat.Core
{
    public class PitchClassGIS : IGIS<PitchClass, BaseInterval>
    {
        static IGIS<PitchClass, BaseInterval> baseGIS = new IntegerGIS().CreateQuotient(new IntegerPitchClassCongruence()); 

        public BaseInterval GetInterval(PitchClass e1, PitchClass e2) => baseGIS.GetInterval(e1, e2);

        public PitchClass Transpose(PitchClass element, BaseInterval interval) => baseGIS.Transpose(element, interval);
    }

    internal class IntegerPitchClassCongruence : ICongruence<int, BaseInterval, int, PitchClass>
    {
        int pitchCount = Enum.GetValues<BasePitch>().Length;

        public BaseInterval GetCongruent(int interval) =>
            new BaseInterval(interval < 0, (Interval)(Math.Abs(interval) % pitchCount));

        public int GetCongruentInverse(BaseInterval interval) => (int)interval.Interval;

        public PitchClass GetEquivalenceClass(int element) => new PitchClass((BasePitch)(element % pitchCount));

        public int GetEquivalenceClassElement(PitchClass element) => (int)element.BasePitch;
    }
}
