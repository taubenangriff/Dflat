using Dflat.Core;

namespace Dflat.Construction
{
    public class Pitches
    {
        #region OctavePitchBuilders 

        public static OctavedPitchBuilder QuadrupleLow() => OctavedPitchBuilder.Create(Octave.Octocontra);

        public static OctavedPitchBuilder TripleLow() => OctavedPitchBuilder.Create(Octave.SubContra);

        public static OctavedPitchBuilder DoubleLow() => OctavedPitchBuilder.Create(Octave.Contra);

        public static OctavedPitchBuilder Low() => OctavedPitchBuilder.Create(Octave.Great);

        public static OctavedPitchBuilder Small() => OctavedPitchBuilder.Create(Octave.Small);

        public static OctavedPitchBuilder OneLined() => OctavedPitchBuilder.Create(Octave.OneLine);

        public static OctavedPitchBuilder TwoLined() => OctavedPitchBuilder.Create(Octave.TwoLine);

        public static OctavedPitchBuilder ThreeLined() => OctavedPitchBuilder.Create(Octave.ThreeLine);

        public static OctavedPitchBuilder QuadrupleLined() => OctavedPitchBuilder.Create(Octave.FourLine);

        public static OctavedPitchBuilder QuintupleLined() => OctavedPitchBuilder.Create(Octave.FiveLine);

        public static OctavedPitchBuilder SixtupleLined() => OctavedPitchBuilder.Create(Octave.SixLine);

        #endregion

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

            #region BasePitchedPitchBuilders

            public BasePitchedPitchBuilder C() => BasePitchedPitchBuilder.Create(Octave, BasePitch.C);

            public BasePitchedPitchBuilder D() => BasePitchedPitchBuilder.Create(Octave, BasePitch.D);

            public BasePitchedPitchBuilder E() => BasePitchedPitchBuilder.Create(Octave, BasePitch.E);

            public BasePitchedPitchBuilder F() => BasePitchedPitchBuilder.Create(Octave, BasePitch.F);

            public BasePitchedPitchBuilder G() => BasePitchedPitchBuilder.Create(Octave, BasePitch.G);

            public BasePitchedPitchBuilder A() => BasePitchedPitchBuilder.Create(Octave, BasePitch.A);

            public BasePitchedPitchBuilder B() => BasePitchedPitchBuilder.Create(Octave, BasePitch.B);

            #endregion
        }


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

            #region PitchBuilders

            public PitchBuilder Sharp() => PitchBuilder.Create(BasePitch, Octave).WithSharp();

            public PitchBuilder DoubleSharp() => PitchBuilder.Create(BasePitch, Octave).WithDoubleSharp();

            public PitchBuilder Flat() => PitchBuilder.Create(BasePitch, Octave).WithFlat();

            public PitchBuilder DoubleFlat() => PitchBuilder.Create(BasePitch, Octave).WithDoubleFlat();

            public PitchBuilder Natural() => PitchBuilder.Create(BasePitch, Octave);

            #endregion
        }
    }
}
