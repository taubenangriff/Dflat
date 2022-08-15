using Dflat.Core;

namespace Dflat.Construction
{
    public class PitchBuilder
    {
        public BasePitch BasePitch { get; private set; }
        public Octave Octave { get; private set; }
        public IHalfToneAccidental? Accidental { get; private set; }
        public IFluentAccidental? AdditionalCentAccidental { get; private set; }

        public Pitch GetResult() => new Pitch(BasePitch, Octave, Accidental, AdditionalCentAccidental);

        private PitchBuilder(Pitch p)
        {
            BasePitch = p.BasePitch;
            Octave = p.Octave;
            Accidental = p.Accidental;
            AdditionalCentAccidental = p.AdditionalCentAccidental;
        }

        private PitchBuilder(BasePitch pitch, Octave octave)
        {
            BasePitch = pitch;
            Octave = octave;
        }

        /// <summary>
        /// Creates a new PitchBuilder instance. If <paramref name="pitch"/> is suitable, it is used to construct a new PitchBuilder. 
        /// </summary>
        /// <param name="pitch"></param>
        /// <returns></returns>
        public static PitchBuilder Create(Pitch pitch)
        {
            return new PitchBuilder(pitch);
        }

        /// <summary>
        /// Creates a new PitchBuilder instance with <paramref name="pitch"/> and <paramref name="octave"/>. The new PitchBuilder does not have any accidentals preapplied.
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="octave"></param>
        /// <returns></returns>
        public static PitchBuilder Create(BasePitch pitch, Octave octave)
        {
            return new PitchBuilder(pitch, octave);
        }

        public PitchBuilder IncreaseBasePitch()
        {
            BasePitch = BasePitch.Next(out bool addOctave);
            Octave = addOctave ? Octave.NextOctave() : Octave;
            return this;
        }

        public PitchBuilder DecreaseBasePitch()
        {
            BasePitch = BasePitch.Previous(out bool subtractOctave);
            Octave = subtractOctave ? Octave.PreviousOctave() : Octave;
            return this;
        }

        public PitchBuilder WithAccidental(IHalfToneAccidental accidental)
        {
            Accidental = accidental;
            return this;
        }

        /// <summary>
        /// Sets <see cref="Accidental"/> to a Sharp Accidental
        /// </summary>
        public PitchBuilder WithSharp() => WithAccidental(Accidentals.Sharp);

        /// <summary>
        /// Sets <see cref="Accidental"/> to a Flat Accidental
        /// </summary>
        public PitchBuilder WithFlat() => WithAccidental(Accidentals.Flat);

        /// <summary>
        /// Sets <see cref="Accidental"/> to a Double Sharp Accidental
        /// </summary>
        public PitchBuilder WithDoubleSharp() => WithAccidental(Accidentals.DoubleSharp);

        /// <summary>
        /// Sets <see cref="Accidental"/> to a Double Flat Accidental
        /// </summary>
        public PitchBuilder WithDoubleFlat() => WithAccidental(Accidentals.DoubleFlat);

        /// <summary>
        /// Sets the Additional Accidental of the note to any <see cref="IFluentAccidental"/>
        /// </summary>
        /// <param name="accidental"></param>
        public PitchBuilder WithFluentAccidental(IFluentAccidental? accidental)
        {
            AdditionalCentAccidental = accidental;
            return this;
        }

        /// <summary>
        /// Adds <paramref name="cents"/> to the note as a cent accidental. -100 &lt;= <paramref name="cents"/> &lt;= 100, otherwise an <see cref="ArgumentException"/>is thrown.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <param name="cents"></param>
        public PitchBuilder ApplyCents(int cents) => WithFluentAccidental(CentAccidental.FromCents(cents));

        /// <summary>
        /// </summary>
        /// <param name="PreferExtraFlats">If true, and the note already has a flat accidental, the note gets a double flat accidental instead of decreasing the base pitch.</param>
        public PitchBuilder Flattened(bool PreferExtraFlats = false)
        {
            if (Accidental is null)
            {
                if (BasePitch.IsHalfToneToPrevious())
                {
                    if (PreferExtraFlats)
                        Accidental = Accidentals.Flat;
                    else
                        DecreaseBasePitch();
                    return this;
                }
                Accidental = Accidentals.Flat;
                return this;
            }

            switch (Accidental.HalfToneAccidentalType)
            {
                case HalfToneAccidentalType.Flat:
                    if (PreferExtraFlats)
                        Accidental = Accidentals.DoubleFlat;
                    else
                    {
                        DecreaseBasePitch();
                        Accidental = null;
                    }
                    break;

                case HalfToneAccidentalType.DoubleFlat:
                    DecreaseBasePitch();
                    Accidental = Accidentals.Flat;
                    break;

                case HalfToneAccidentalType.Sharp:
                    Accidental = null;
                    break;

                case HalfToneAccidentalType.DoubleSharp:
                    Accidental = Accidentals.Sharp;
                    break;
            }
            return this;
        }

        /// <param name="PreferDoubleFlat">If true, and the note already has a sharp accidental, the note gets a double sharp accidental instead of increasing the base pitch.</param>
        public PitchBuilder Sharpened(bool PreferExtraSharp = false)
        {
            if (Accidental is null)
            {
                if (BasePitch.IsHalfToneToNext())
                {
                    if (PreferExtraSharp)
                        Accidental = Accidentals.Sharp;
                    else
                        IncreaseBasePitch();
                    return this;
                }
                Accidental = Accidentals.Sharp;
                return this;
            }

            switch (Accidental.HalfToneAccidentalType)
            {
                case HalfToneAccidentalType.Sharp:
                    if (PreferExtraSharp)
                        Accidental = Accidentals.DoubleSharp;
                    else
                    {
                        IncreaseBasePitch();
                        Accidental = null;
                    }

                    break;

                case HalfToneAccidentalType.DoubleSharp:
                    IncreaseBasePitch();
                    Accidental = Accidentals.Sharp;
                    break;

                case HalfToneAccidentalType.Flat:
                    Accidental = null;
                    break;

                case HalfToneAccidentalType.DoubleFlat:
                    Accidental = Accidentals.Flat;
                    break;
            }
            return this;
        }
    }
}
