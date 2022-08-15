using Dflat.Core;

namespace Dflat.Construction
{
    public class Durations
    {

        public class BaseDurationedDurationBuilder
        {
            public BaseDuration BaseDuration { get; }
            private BaseDurationedDurationBuilder(BaseDuration baseDuration)
            { 
                BaseDuration = baseDuration;
            }
            public static BaseDurationedDurationBuilder Create(BaseDuration baseDuration)
            {
                return new BaseDurationedDurationBuilder(baseDuration);
            }

            public DurationBuilder WithoutDot() => DurationBuilder.Create(BaseDuration);

            public DurationBuilder WithDot() => DurationBuilder.Create(BaseDuration, DurationAccidentals.OneDot);

            public DurationBuilder WithTwoDots() => DurationBuilder.Create(BaseDuration, DurationAccidentals.TwoDots);

            public DurationBuilder WithThreeDots() => DurationBuilder.Create(BaseDuration, DurationAccidentals.ThreeDots);
        }

        public static BaseDurationedDurationBuilder DoubleWhole() => BaseDurationedDurationBuilder.Create(BaseDuration.DoubleWhole);
        
        public static BaseDurationedDurationBuilder Whole() => BaseDurationedDurationBuilder.Create(BaseDuration.Whole);

        public static BaseDurationedDurationBuilder Half() => BaseDurationedDurationBuilder.Create(BaseDuration.Half);

        public static BaseDurationedDurationBuilder Quarter() => BaseDurationedDurationBuilder.Create(BaseDuration.Quarter);

        public static BaseDurationedDurationBuilder Eighth() => BaseDurationedDurationBuilder.Create(BaseDuration.Eighth);

        public static BaseDurationedDurationBuilder Sixteenth() => BaseDurationedDurationBuilder.Create(BaseDuration.Sixteenth);

        public static BaseDurationedDurationBuilder ThirtySecond() => BaseDurationedDurationBuilder.Create(BaseDuration.ThirtySecond);

        public static BaseDurationedDurationBuilder SixtyFourth() => BaseDurationedDurationBuilder.Create(BaseDuration.SixtyFourth);

        public static BaseDurationedDurationBuilder HundredTwentyEighth() => BaseDurationedDurationBuilder.Create(BaseDuration.HundredTwentyEighth)
    }

   
}
