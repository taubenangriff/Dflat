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
    }
}
