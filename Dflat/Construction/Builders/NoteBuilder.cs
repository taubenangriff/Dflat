using Dflat.Core;

namespace Dflat.Construction
{
    public class NoteBuilder : IBuilder<Note>
    {
        public PitchBuilder PitchBuilder { get; private set; }

        public DurationBuilder DurationBuilder { get; private set; }

        private NoteBuilder(PitchBuilder p, DurationBuilder d)
        {
            PitchBuilder = p;
            DurationBuilder = d;
        }

        /// <summary>
        /// Creates a new NoteBuilder with a new PitchBuilder on Middle C.
        /// </summary>
        /// <returns></returns>
        public static NoteBuilder Create()
        {
            return new NoteBuilder(PitchBuilder.Create(), DurationBuilder.Create());
        }

        public static NoteBuilder Create(Note note)
        {
            return new NoteBuilder(PitchBuilder.Create(note.Pitch), DurationBuilder.Create(note.Duration));
        }

        public static NoteBuilder Create(
            PitchBuilder? pitchBuilder = null,
            DurationBuilder? durationBuilder = null)
        {
            return new NoteBuilder(
                pitchBuilder ?? PitchBuilder.Create(),
                durationBuilder ?? DurationBuilder.Create()
            );
        }

        public NoteBuilder WithPitch(PitchBuilder pitchBuilder)
        {
            PitchBuilder = pitchBuilder;
            return this;
        }

        public NoteBuilder ModifyCurrentPitch(Func<PitchBuilder, PitchBuilder> PitchBuilderFunc)
        {
            PitchBuilder = PitchBuilderFunc.Invoke(PitchBuilder);
            return this;
        }

        public NoteBuilder WithDuration(DurationBuilder durationBuilder)
        {
            DurationBuilder = durationBuilder;
            return this;
        }

        public NoteBuilder ModifyDuration(Func<DurationBuilder, DurationBuilder> DurationBuilderFunc)
        {
            DurationBuilder = DurationBuilderFunc.Invoke(DurationBuilder);
            return this;
        }

        public Note GetResult() => new Note(PitchBuilder.GetResult());
    }
}
