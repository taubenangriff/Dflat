namespace Dflat.Core.Construction
{
    public class DurationBuilder : IBuilder<Duration>
    {
        public BaseDuration BaseDuration { get; private set; }
        public DurationAccidental? DurationAccidental { get; private set; }
        
        private DurationBuilder(
            BaseDuration baseDuration, 
            DurationAccidental? durationAccidental = null) 
        {
            BaseDuration = baseDuration;
            DurationAccidental = durationAccidental;
        }

        public Duration Build()
        {
            return new Duration(BaseDuration, DurationAccidental);
        }

        public static DurationBuilder Create(BaseDuration baseDuration, DurationAccidental? durationAccidental = null)
        {
            return new DurationBuilder(baseDuration, durationAccidental);
        }

        public static DurationBuilder Create(Duration duration)
        {
            return new DurationBuilder(duration.BaseDuration, duration.DotAccidental);
        }

        /// <summary>
        /// Creates a DurationBuilder with Duration of a Whole Note
        /// </summary>
        /// <returns></returns>
        public static DurationBuilder Create()
        {
            return Durations.Whole().WithDot();
        }

        public DurationBuilder WithBaseDuration(BaseDuration baseDuration)
        {
            BaseDuration = baseDuration;
            return this;        
        }

        public DurationBuilder WithOneDot()
        {
            DurationAccidental = DurationAccidentals.OneDot;
            return this;
        }

        public DurationBuilder WithTwoDots()
        {
            DurationAccidental = DurationAccidentals.TwoDots;
            return this;
        }

        public DurationBuilder WithThreeDots()
        { 
            DurationAccidental=DurationAccidentals.ThreeDots;
            return this;
        }

        public DurationBuilder WithoutDot()
        {
            DurationAccidental = null;
            return this;
        }
    }
}
