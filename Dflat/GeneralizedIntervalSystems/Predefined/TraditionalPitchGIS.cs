using Dflat.Core;
using Dflat.Intervals;
using Dflat.Pitches;

namespace Dflat.GeneralizedIntervalSystems.Predefined
{
    public class TraditionalPitchGIS : IGeneralizedIntervalSystem<Pitch, Interval>
    {
        public IBuilder<Pitch> ApplyIntervalForBuilder(Pitch element, Interval interval)
        {
            throw new NotImplementedException();
        }

        public IBuilder<Interval> GetIntervalAsBuilder(Pitch e1, Pitch e2)
        {
            //Base Interval = pitch 1 - pitch 2 
            //Direction: Up if e1 > e2
            //Modifier = difference between base interval steps and pitch1-pitch2

            //shortcut the unison
            int comparison = e2.CompareTo(e1);
            if(comparison == 0)
                return MainIntervals.Perfect().Unison().Up();

            var builder = IntervalBuilder.Create();
            _ = comparison > 0 ?
                builder.Upwards()
                : builder.Downwards();

            if (comparison < 0)
                (e1, e2) = (e2, e1);

            //compute baseInterval: e2-e1, add 12 if the difference is negative. Then cast to baseinterval.
            var integerDiff = ((int)e2.BasePitch) - ((int)e1.BasePitch) + (comparison < 0 ? 12 : 0);
            var intervalDiff = (BaseInterval)integerDiff;

            //intervalmodifier: if perfect, we can only augment or diminish
            if (intervalDiff.IsPerfect())
            {
                builder.WithModifier(IntervalModifier.Major);
            }

            builder.WithBaseInterval(intervalDiff);
            return builder;
        }
    }
}
