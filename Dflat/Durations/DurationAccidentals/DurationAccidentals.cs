namespace Dflat.Durations
{
    public static class DurationAccidentals
    {
        public static DurationAccidental OneDot { get; } = new OneDotDurationAccidental();
        public static DurationAccidental TwoDots { get; } = new TwoDotsDurationAccidental();
        public static DurationAccidental ThreeDots { get; } = new ThreeDotsDurationAccidental();
    }

    public class OneDotDurationAccidental : DurationAccidental
    {
        public override float DurationFactor { get; } = 1.5f;
    }

    public class TwoDotsDurationAccidental : DurationAccidental
    {
        public override float DurationFactor { get; } = 1.75f;
    }

    public class ThreeDotsDurationAccidental : DurationAccidental
    {
        public override float DurationFactor { get; } = 1.875f;
    }
}
