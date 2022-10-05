using Dflat.Core;
using Dflat.Core.Construction;

namespace Dflat.Chords.Construction
{
    public class ChordBuilder : IBuilder<Chord, ChordBuilder>
    {
        public DurationBuilder DurationBuilder { get; protected set; }

        public ICollection<PitchBuilder> PitchBuilders { get; protected set; }
        public PitchBuilder? RootNote { get; private set; } = null;

        protected ChordBuilder(DurationBuilder durationBuilder)
        {
            DurationBuilder = durationBuilder;
            PitchBuilders = new List<PitchBuilder>();
        }

        /// <summary>
        /// Creates a ChordBuilder from the current Chord <paramref name="chord"/>
        /// </summary>
        /// <param name="chord"></param>
        /// <returns></returns>
        public static ChordBuilder Create(Chord chord)
        {
            var builder = new ChordBuilder(
                    DurationBuilder.Create(chord.Duration)
                );
            foreach (Pitch p in chord.Pitches)
                builder.AddPitch(PitchBuilder.Create(p));
            return builder;
        }

        public static ChordBuilder Create(ICollection<PitchBuilder> pitchBuilders, DurationBuilder durationBuilder)
        {
            return new ChordBuilder(durationBuilder)
            {
                PitchBuilders = pitchBuilders
            };
        }

        /// <summary>
        /// Creates a Chord with default duration and no pitches.
        /// </summary>
        /// <returns></returns>
        public static ChordBuilder Create()
        {
            return new ChordBuilder(DurationBuilder.Create());
        }

        public Chord Build()
        {
            return new Chord(
                //pitches
                PitchBuilders.Select(x => x.Build()).ToList(),
                DurationBuilder.Build()
            );
        }

        public ChordBuilder DeepClone() => ChordBuilder.Create(this.Build());

        public bool HasRootNote() => RootNote is not null;

        public ChordBuilder AddPitch(PitchBuilder pitchBuilder)
        {
            PitchBuilders.Add(pitchBuilder);
            return this;
        }

        public ChordBuilder WithRootNote(PitchBuilder pitchBuilder, bool addPitchToChord = true)
        {
            if (addPitchToChord)
                AddPitch(pitchBuilder);
            RootNote = pitchBuilder;
            return this;
        }

        public ChordBuilder WithDuration(DurationBuilder durationBuilder)
        {
            DurationBuilder = durationBuilder;
            return this;
        }

        public ChordBuilder ModifyCurrentDuration(Func<DurationBuilder, DurationBuilder> durationBuilderFunc)
        {
            DurationBuilder = durationBuilderFunc.Invoke(DurationBuilder);
            return this;
        }

        public ChordBuilder ModifyAllCurrentPitches(Func<PitchBuilder, PitchBuilder> pitchBuilderFunc)
        {
            foreach (var pitchBuilder in PitchBuilders)
            {
                pitchBuilderFunc.Invoke(pitchBuilder);
            }
            return this;
        }

        /// <summary>
        /// Removes a pitch from the chord, specified through <paramref name="pitchBuilder"/>. 
        /// <br />
        /// <paramref name="useEnharmonicComparison"/>: true if equality should be determined by enharmonic comparison,
        /// false if the pitches should be compared based on base pitch and accidentals. 
        /// Example: if true, Eb and D# are considered equal, if false, only Eb and Eb are equal.
        /// </summary>
        /// <param name="pitchBuilder"></param>
        /// <returns></returns>
        /// <param name="useEnharmonicComparison"></param>
        public ChordBuilder FilterOutPitch(PitchBuilder pitchBuilder, bool useEnharmonicComparison = true)
        {
            var pitch = pitchBuilder.Build();
            if (useEnharmonicComparison)
                PitchBuilders = PitchBuilders.Where(x => x.Build().IsEnharmonicTo(pitch)).ToList();
            else
                PitchBuilders = PitchBuilders.Where(x => x.Build().Equals(pitch)).ToList();
            return this;
        }

        public ChordBuilder RemovePitch(PitchBuilder pitchBuilder)
        {
            PitchBuilders.Remove(pitchBuilder);
            return this;
        }

        public TChordBuilder UseAs<TChordBuilder>() where TChordBuilder : ChordBuilder
        {
            var newBuilder = this as TChordBuilder;
            if (newBuilder is null) throw new InvalidOperationException($"Cannot cast {this.GetType()} to {typeof(TChordBuilder)}");
            return newBuilder;
        }

        public ChordBuilder EnsureRootNoteExists()
        {
            if (!HasRootNote())
                throw new InvalidOperationException("Chord does not have a root note. A root note needs to be set for the operation.");
            return this;
        }
    }
}
