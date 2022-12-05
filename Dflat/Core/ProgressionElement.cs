using Dflat.Durations;

namespace Dflat.Core
{
    /// <summary>
    /// Toplevel Abstraction for any sounding element that can occur in a musical progression :
    /// Chords, Notes, Pauses, etc.
    /// </summary>
    /// 

    public enum ProgressionElementType { Note, Chord, Pause }

    public abstract class ProgressionElement
    {
        public abstract Duration Duration { get; init; }
        public abstract ProgressionElementType ElementType { get; }
    }
}
