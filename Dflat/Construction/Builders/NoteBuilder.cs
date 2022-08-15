using Dflat.Core;

namespace Dflat.Construction
{
    public class NoteBuilder
    {
        public PitchBuilder PitchBuilder { get; private set; }

        private NoteBuilder(PitchBuilder p)
        {
            PitchBuilder = p;
        }

        /// <summary>
        /// Creates a new NoteBuilder with a new PitchBuilder on Middle C.
        /// </summary>
        /// <returns></returns>
        public static NoteBuilder Create()
        {
            return new NoteBuilder(Pitches.Small().C().Natural());
        }

        public static NoteBuilder Create(Note note)
        {
            return new NoteBuilder(PitchBuilder.Create(note.Pitch));
        }

        public static NoteBuilder Create(PitchBuilder p)
        {
            return new NoteBuilder(p);
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

        public Note GetResult() => new Note(PitchBuilder.GetResult());
    }
}
