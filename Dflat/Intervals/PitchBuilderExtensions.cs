using Dflat.Core.Construction;

namespace Dflat.Intervals
{
    public static class PitchBuilderExtensions
    {
        public static PitchBuilder TransposeBy(this PitchBuilder pitchBuilder, Interval interval)
        {
            bool preferExtraAccidental = interval.Modifier == IntervalModifier.Augmented
                || interval.Modifier == IntervalModifier.Diminished;

            if (interval.Direction == IntervalDirection.Up)
            {
                for (int i = 0; i < interval.GetHalfSteps(); i++)
                {
                    pitchBuilder.Sharpened(preferExtraAccidental);
                }
            }
            else
            {
                for (int i = interval.GetHalfSteps(); i > 0; i--)
                {
                    pitchBuilder.Flattened(preferExtraAccidental);
                }
            }
            return pitchBuilder;
        }
    }
}
