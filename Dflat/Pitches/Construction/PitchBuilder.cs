using Dflat.Core;

namespace Dflat.Pitches
{
    public class PitchBuilder : IBuilder<Pitch, PitchBuilder>
    {
        public BasePitch BasePitch { get; private set; }
        public Octave Octave { get; private set; }
        public IHalfToneAccidental? Accidental { get; private set; }
        public IFluentAccidental? AdditionalCentAccidental { get; private set; }

        public Pitch Build() => new Pitch(BasePitch, Octave, Accidental, AdditionalCentAccidental);

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

        /// <summary>
        /// Creates a PitchBuilder on Middle C;
        /// </summary>
        /// <returns></returns>
        public static PitchBuilder Create()
        {
            return Pitches.Small().C().Natural();
        }

        public PitchBuilder DeepClone() => PitchBuilder.Create(this.Build());

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

        public PitchBuilder OctaveUp()
        {
            Octave = Octave.NextOctave();
            return this;
        }

        public PitchBuilder OctaveDown()
        {
            Octave = Octave.PreviousOctave();
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

        public PitchBuilder FlattenedTimes(int times, bool PreferExtraFlats = false)
        {
            for (int i = 0; i < times; i++)
            {
                Flattened(PreferExtraFlats);
            }
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="PreferExtraFlats">If true, and the note already has a flat accidental, the note gets a double flat accidental instead of decreasing the base pitch.</param>
        public PitchBuilder Flattened(bool PreferExtraFlats = false)
        {
            //if we are at a half tone, preferExtraFlats only ever will produce one Flat.
            if (BasePitch.IsHalfToneToPrevious())
            {
                if (PreferExtraFlats && Accidental is null)
                    Accidental = Accidentals.Flat;
                else if (PreferExtraFlats && Accidental is not null && Accidental!.HalfToneAccidentalType == HalfToneAccidentalType.Flat)
                    Accidental = Accidentals.DoubleFlat;
                else
                    DecreaseBasePitch();

                return this;
            }
            //in case there is no accidental, just sharpen
            if (Accidental is null)
            {
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

        public PitchBuilder SharpenedTimes(int times, bool PreferExtraSharp = false)
        {
            for (int i = 0; i < times; i++)
            {
                Sharpened(PreferExtraSharp);
            }
            return this;
        }

        /// <param name="PreferDoubleFlat">If true, and the note already has a sharp accidental, the note gets a double sharp accidental instead of increasing the base pitch.</param>
        public PitchBuilder Sharpened(bool PreferExtraSharp = false)
        {
            //if we are at a half tone, preferExtraSharp only ever will produce one Sharp.
            if (BasePitch.IsHalfToneToNext())
            {
                if (PreferExtraSharp && Accidental is null)
                    Accidental = Accidentals.Sharp;
                else if(PreferExtraSharp && Accidental is not null && Accidental!.HalfToneAccidentalType == HalfToneAccidentalType.Sharp)
                    Accidental = Accidentals.DoubleSharp;
                else
                    IncreaseBasePitch();

                return this;
            }
            //in case there is no accidental, just sharpen
            if (Accidental is null)
            {
                Accidental = Accidentals.Sharp;
                return this;
            }

            //default tones
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

        public PitchBuilder TransposeByHalfSteps(int times, bool PreferExtraAccidentals = false)
        {
            return times > 0 ? SharpenedTimes(times, PreferExtraAccidentals) : FlattenedTimes(times * -1, PreferExtraAccidentals);
        }
    }
}
