using Dflat.Core;
using Dflat.Intervals;

namespace Dflat.Chords
{
    public class TriadBuilder : ChordBuilder, IBuilder<Chord, TriadBuilder>
    {
        private TriadBuilder(DurationBuilder durationBuilder) : base(durationBuilder)
        {
        }

        TriadBuilder IBuilder<Chord, TriadBuilder>.DeepClone() => base.DeepClone().UseAs<TriadBuilder>();

        /// <summary>
        /// Creates a TriadBuilder with default duration and no pitches.
        /// </summary>
        /// <returns></returns>
        public new static TriadBuilder Create()
        {
            return new TriadBuilder(DurationBuilder.Create());
        }

        public new static TriadBuilder Create(ICollection<PitchBuilder> pitchBuilders, DurationBuilder durationBuilder)
        {
            return new TriadBuilder(durationBuilder)
            {
                PitchBuilders = pitchBuilders
            };
        }

        public TriadBuilder AddMajorTriadOn(PitchBuilder pitch)
        {
            PitchBuilders.Add(pitch);
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Major().Third().Up().Build()));
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Perfect().Fifth().Up().Build()));
            return this;
        }

        public TriadBuilder AddMinorTriadOn(PitchBuilder pitch)
        {
            PitchBuilders.Add(pitch);
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Minor().Third().Up().Build()));
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Perfect().Fifth().Up().Build()));
            return this;
        }

        public TriadBuilder AddDiminishedTriadOn(PitchBuilder pitch)
        {
            PitchBuilders.Add(pitch);
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Minor().Third().Up().Build()));
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Diminished().Fifth().Up().Build()));
            return this;
        }

        public TriadBuilder AddAugmentedTriadOn(PitchBuilder pitch)
        {
            PitchBuilders.Add(pitch);
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Major().Third().Up().Build()));
            PitchBuilders.Add(pitch.DeepClone().TransposeBy(MainIntervals.Augmented().Fifth().Up().Build()));
            return this;
        }
    }
}
