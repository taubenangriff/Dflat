namespace Dflat.Intervals.Construction
{
    public static class MainIntervals
    {
        public static MajorMinorIntervalModifierBuilder Minor() => MajorMinorIntervalModifierBuilder.Create(IntervalModifier.Minor);

        public static MajorMinorIntervalModifierBuilder Major() => MajorMinorIntervalModifierBuilder.Create(IntervalModifier.Major);

        public static AugDimIntervalModifierBuilder Augmented() => AugDimIntervalModifierBuilder.Create(IntervalModifier.Augmented);

        public static AugDimIntervalModifierBuilder Diminished() => AugDimIntervalModifierBuilder.Create(IntervalModifier.Diminished);

        public static PerfectIntervalModifierBuilder Perfect() => PerfectIntervalModifierBuilder.Create();

        public class MajorMinorIntervalModifierBuilder
        {
            public IntervalModifier IntervalModifier { get; }

            private MajorMinorIntervalModifierBuilder(IntervalModifier mod)
            {
                IntervalModifier = mod;
            }

            public static MajorMinorIntervalModifierBuilder Create(IntervalModifier intervalModifier)
            {
                return new MajorMinorIntervalModifierBuilder(intervalModifier);
            }

            public DirectionIntervalModifierBuilder Second() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Second);
            public DirectionIntervalModifierBuilder Third() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Third);
            public DirectionIntervalModifierBuilder Sixth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Sixth);
            public DirectionIntervalModifierBuilder Seventh() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Seventh);
            public DirectionIntervalModifierBuilder Ninth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Ninth);
            public DirectionIntervalModifierBuilder Tenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Tenth);
            public DirectionIntervalModifierBuilder Thirteenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Thirteenth);
            public DirectionIntervalModifierBuilder Fourteenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fourteenth);
        }

        public class PerfectIntervalModifierBuilder
        {
            public IntervalModifier IntervalModifier { get; }

            private PerfectIntervalModifierBuilder()
            {
                IntervalModifier = IntervalModifier.Major;
            }

            public static PerfectIntervalModifierBuilder Create()
            {
                return new PerfectIntervalModifierBuilder();
            }

            public DirectionIntervalModifierBuilder Unison() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Unison);
            public DirectionIntervalModifierBuilder Fourth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fourth);
            public DirectionIntervalModifierBuilder Fifth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fifth);
            public DirectionIntervalModifierBuilder Octave() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Octave);
            public DirectionIntervalModifierBuilder Eleventh() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Eleventh);
            public DirectionIntervalModifierBuilder Twelfth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Twelfth);
            public DirectionIntervalModifierBuilder Fifteenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fifteenth);
        }

        public class AugDimIntervalModifierBuilder
        {
            public IntervalModifier IntervalModifier { get; }

            private AugDimIntervalModifierBuilder(IntervalModifier mod)
            {
                IntervalModifier = mod;
            }

            public static AugDimIntervalModifierBuilder Create(IntervalModifier intervalModifier)
            {
                return new AugDimIntervalModifierBuilder(intervalModifier);
            }

            public DirectionIntervalModifierBuilder Second() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Second);
            public DirectionIntervalModifierBuilder Third() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Third);
            public DirectionIntervalModifierBuilder Sixth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Sixth);
            public DirectionIntervalModifierBuilder Seventh() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Seventh);
            public DirectionIntervalModifierBuilder Ninth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Ninth);
            public DirectionIntervalModifierBuilder Tenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Tenth);
            public DirectionIntervalModifierBuilder Thirteenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Thirteenth);
            public DirectionIntervalModifierBuilder Fourteenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fourteenth);
            public DirectionIntervalModifierBuilder Unison() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Unison);
            public DirectionIntervalModifierBuilder Fourth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fourth);
            public DirectionIntervalModifierBuilder Fifth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fifth);
            public DirectionIntervalModifierBuilder Octave() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Octave);
            public DirectionIntervalModifierBuilder Eleventh() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Eleventh);
            public DirectionIntervalModifierBuilder Twelfth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Twelfth);
            public DirectionIntervalModifierBuilder Fifteenth() => DirectionIntervalModifierBuilder.Create(IntervalModifier, BaseInterval.Fifteenth);

        }

        public class DirectionIntervalModifierBuilder
        {
            public IntervalModifier IntervalModifier { get; }
            public BaseInterval Interval { get; }

            private DirectionIntervalModifierBuilder(IntervalModifier modifier, BaseInterval interval)
            {
                IntervalModifier = modifier;
                Interval = interval;
            }

            public static DirectionIntervalModifierBuilder Create(
                IntervalModifier modifier, 
                BaseInterval interval)
            {
                return new DirectionIntervalModifierBuilder(modifier, interval);
            }

            public IntervalBuilder Up()
            {
                return IntervalBuilder.Create().WithBaseInterval(Interval).WithModifier(IntervalModifier).Upwards();
            }

            public IntervalBuilder Down()
            {
                return IntervalBuilder.Create().WithBaseInterval(Interval).WithModifier(IntervalModifier).Downwards();
            }
        }
    }
}
