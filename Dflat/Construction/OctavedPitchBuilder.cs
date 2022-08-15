using Dflat.Core;

namespace Dflat.Construction
{
    public class OctavedPitchBuilder
    {
        public Octave Octave { get; }

        private OctavedPitchBuilder(Octave oct)
        {
            Octave = oct;
        }

        internal static OctavedPitchBuilder Create(Octave oct)
        {
            return new OctavedPitchBuilder(oct);
        }

        public BasePitchedPitchBuilder C() => BasePitchedPitchBuilder.Create(Octave, BasePitch.C);

        public BasePitchedPitchBuilder D() => BasePitchedPitchBuilder.Create(Octave, BasePitch.D);

        public BasePitchedPitchBuilder E() => BasePitchedPitchBuilder.Create(Octave, BasePitch.E);

        public BasePitchedPitchBuilder F() => BasePitchedPitchBuilder.Create(Octave, BasePitch.F);

        public BasePitchedPitchBuilder G() => BasePitchedPitchBuilder.Create(Octave, BasePitch.G);

        public BasePitchedPitchBuilder A() => BasePitchedPitchBuilder.Create(Octave, BasePitch.A);

        public BasePitchedPitchBuilder B() => BasePitchedPitchBuilder.Create(Octave, BasePitch.B);
    }
}
