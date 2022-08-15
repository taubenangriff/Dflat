namespace Dflat.Core
{
    public class Duration
    {
        public BaseDuration BaseDuration { get; init; }
        public DurationAccidental? DotAccidental { get; init; }

        public Duration(BaseDuration baseDuration,
            DurationAccidental? dotAccidental = null)
        {
            BaseDuration = baseDuration;
            DotAccidental = dotAccidental;
        }

        public bool HasDot() => DotAccidental is not null;
    }
}
