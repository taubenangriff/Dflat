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

        public int CompareTo(Pitch? other)
        {
            if (other is not Pitch other_pitch) return -1;

            var octave_comp = Octave.CompareTo(other_pitch.Octave);
            if (octave_comp != 0)
                return octave_comp;

            var basepitch_comp = BasePitch.CompareTo(other_pitch.BasePitch);
            if (basepitch_comp != 0)
                return basepitch_comp;

            return accidentalSum.CompareTo(other_pitch.accidentalSum);
        }

        public bool EnharmonicTo(Pitch? other)
        {
            if (other is not Pitch other_pitch) return false;
            float self = ((float)Octave * 12)
                + (float)BasePitch
                + accidentalSum;

            float other_val = ((float)other_pitch.Octave * 12)
                + (float)other_pitch.BasePitch
                + other_pitch.accidentalSum;

            return self == other_val;
        }

        public int CompareEnharmonicTo(Pitch? other)
        {
            if (other is not Pitch other_pitch) return -1;
            float self = ((float)Octave * 12)
                + (float)BasePitch
                + accidentalSum;

            float other_val = ((float)other_pitch.Octave * 12)
                + (float)other_pitch.BasePitch
                + other_pitch.accidentalSum;

            return self.CompareTo(other_val);
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
