namespace Dflat.Core
{
    /// <summary>
    /// Represents an immutable Pitch with Base Pitch, Octave and accidentals.
    /// </summary>
    public class Pitch : IComparable<Pitch>, IEquatable<Pitch>
    {
        public BasePitch BasePitch { get; init; }
        public Octave Octave { get; init; }
        public IHalfToneAccidental? Accidental { get; init; }
        public IFluentAccidental? AdditionalCentAccidental { get; init; }

        private float accidentalSum;

        private float fullSum => 
                ((float)Octave * 12)
                + (float)BasePitch
                + accidentalSum;

        public Pitch(
            BasePitch pitch, 
            Octave octave, 
            IHalfToneAccidental? accidental, 
            IFluentAccidental? additionalCentAccidental)
        { 
            BasePitch = pitch;
            Octave = octave;
            Accidental = accidental;
            AdditionalCentAccidental = additionalCentAccidental;

            accidentalSum = Accidental?.PitchShift ?? 0 + AdditionalCentAccidental?.PitchShift ?? 0;
        }

        public override string ToString()
        {
            return BasePitch.ToString() + Accidental?.GetRepresentation() + Octave.GetRepresentation() + AdditionalCentAccidental?.GetRepresentation();
        }

        public bool HasAccidental() => Accidental is not null;

        public bool HasAdditionalCentAccidental() => AdditionalCentAccidental is not null;

        //Todo CompareTo => equivalence 
        //Todo Equals => equality

        public int CompareTo(Pitch? other)
        {
            if (other is not Pitch other_pitch) return -1;
            return fullSum.CompareTo(other_pitch.fullSum);
        }

        public bool EnharmonicTo(Pitch? other)
        {
            if (other is not Pitch other_pitch) return false;
            return fullSum == other_pitch.fullSum;
        }

        public bool Equals(Pitch? other)
        {
            if (other is not Pitch other_pitch) return false;

            return Octave.Equals(other_pitch.Octave)
                && BasePitch.Equals(other_pitch.BasePitch)
                && accidentalSum.Equals(other_pitch.accidentalSum);
        }
    }
}
