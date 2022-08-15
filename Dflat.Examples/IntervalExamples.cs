using Dflat.Intervals;
using Dflat.Intervals.Construction;

namespace Dflat.Examples
{
    internal class IntervalExamples
    {
        public static void CreateInterval()
        {
            var interval = AllIntervals.Perfect().Fifth().Up();
        }
    }
}
