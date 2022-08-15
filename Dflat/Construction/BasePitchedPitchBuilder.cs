using Dflat.Core;

namespace Dflat.Construction
{
    public class BasePitchedPitchBuilder
    {
        public Octave Octave { get; }
        public BasePitch BasePitch { get; }

        private BasePitchedPitchBuilder(Octave oct, BasePitch basePitch)
        {
            Octave = oct;
            BasePitch = basePitch;
        }

        internal static BasePitchedPitchBuilder Create(Octave oct, BasePitch basePitch)
        { 
            return new BasePitchedPitchBuilder(oct, basePitch);
        }

        public PitchBuilder Sharp() => PitchBuilder.Create(BasePitch, Octave).WithSharp();

        public PitchBuilder DoubleSharp() => PitchBuilder.Create(BasePitch, Octave).WithDoubleSharp();

        public PitchBuilder Flat() => PitchBuilder.Create(BasePitch, Octave).WithFlat();

        public PitchBuilder DoubleFlat() => PitchBuilder.Create(BasePitch, Octave).WithDoubleFlat();

        public PitchBuilder Natural() => PitchBuilder.Create(BasePitch, Octave);
    }
}
