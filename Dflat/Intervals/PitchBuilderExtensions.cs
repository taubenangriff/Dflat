using Dflat.Pitches;

namespace Dflat.Intervals
{
    public static class PitchBuilderExtensions
    {
        public static PitchBuilder TransposeBy(this PitchBuilder pitchBuilder, Interval interval)
        {
            bool preferExtraAccidental = interval.Modifier == IntervalModifier.Augmented
                || interval.Modifier == IntervalModifier.Diminished;

            pitchBuilder = pitchBuilder.TransposeByHalfSteps(interval.GetBaseHalfSteps());
            pitchBuilder = pitchBuilder.TransposeByHalfSteps(interval.GetModifierHalfSteps(), preferExtraAccidental);
            return pitchBuilder;
        }
    }
}
