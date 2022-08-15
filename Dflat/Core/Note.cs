namespace Dflat.Core
{
    /// <summary>
    /// A note is immutable. Every change to a note will have to return a new note!
    /// </summary>
    public sealed class Note : ProgressionElement
    {
        public Pitch Pitch { get; init; }
        public override Duration Duration { get; init; }
        public override ProgressionElementType ElementType { get; } = ProgressionElementType.Note;

        internal Note(Pitch pitch, Duration duration)
        {
            Pitch = pitch;
            Duration = duration;
        }
    }
}
