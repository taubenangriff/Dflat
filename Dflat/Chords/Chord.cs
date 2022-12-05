using Dflat.Core;
using Dflat.Durations;
using Dflat.Pitches;
using System.Collections;

namespace Dflat.Chords
{
    public class Chord : ProgressionElement, IEnumerable<Pitch>, IEquatable<Chord>
    {
        public override Duration Duration { get; init; }

        public override ProgressionElementType ElementType { get; } = ProgressionElementType.Chord;

        public IEnumerable<Pitch> Pitches { get; init; }

        public Chord(IEnumerable<Pitch> pitches,
            Duration duration)
        {
            Duration = duration;
            Pitches = pitches;
        }

        public IEnumerator<Pitch> GetEnumerator() => Pitches.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Pitches.GetEnumerator();

        public bool Equals(Chord? other)
        {
            if (other is not Chord chord) return false;

            //check if this chord has any pitches not in the other chord
            //and if other chord has any pitches not in this chord.
            return Pitches.Any( x => !chord.Pitches.Any(y => x.Equals(y))) 
                && chord.Pitches.Any(x => !Pitches.Any(y => x.Equals(y)));
        }

        public bool EqualsEnharmonic(Chord? other)
        {
            if (other is not Chord chord) return false;

            return Pitches.Any(x => !chord.Pitches.Any(y => x.IsEnharmonicTo(y)))
                && chord.Pitches.Any(x => !Pitches.Any(y => x.IsEnharmonicTo(y)));
        }
    }
}
