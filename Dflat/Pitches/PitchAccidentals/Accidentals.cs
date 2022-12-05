namespace Dflat.Pitches
{
    /// <summary>
    /// A range of Predefined HalfToneAccidentals
    /// </summary>
    public static class Accidentals
    {
        public static SharpAccidental Sharp { get; } = new SharpAccidental();
        public static DoubleSharpAccidental DoubleSharp { get; } = new DoubleSharpAccidental();
        public static FlatAccidental Flat { get; } = new FlatAccidental();
        public static DoubleFlatAccidental DoubleFlat { get; } = new DoubleFlatAccidental();
    }

    public class SharpAccidental : IHalfToneAccidental
    {
        public int PitchShift { get; init; } = 1;
        public AccidentalCharacter AccidentalCharacter { get; } = AccidentalCharacter.Sharp;
        public AccidentalType AccidentalType { get; } = AccidentalType.HalfTone;
        public HalfToneAccidentalType HalfToneAccidentalType { get; } = HalfToneAccidentalType.Sharp;

        internal SharpAccidental() { }
        public String GetRepresentation() => "#";
    }

    public class DoubleSharpAccidental : IHalfToneAccidental
    {
        public int PitchShift { get; init; } = 2; 
        public AccidentalCharacter AccidentalCharacter { get; } = AccidentalCharacter.Sharp;
        public AccidentalType AccidentalType { get; } = AccidentalType.HalfTone;
        public HalfToneAccidentalType HalfToneAccidentalType { get; } = HalfToneAccidentalType.DoubleSharp;

        internal DoubleSharpAccidental() { }
        public String GetRepresentation() => "𝄪";

    }

    public class FlatAccidental : IHalfToneAccidental
    {
        public int PitchShift { get; init; } = -1; 
        public AccidentalCharacter AccidentalCharacter { get; } = AccidentalCharacter.Flat;
        public AccidentalType AccidentalType { get; } = AccidentalType.HalfTone;
        public HalfToneAccidentalType HalfToneAccidentalType { get; } = HalfToneAccidentalType.Flat;

        internal FlatAccidental() { }
        public String GetRepresentation() => "♭";
    }

    public class DoubleFlatAccidental : IHalfToneAccidental
    {
        public int PitchShift { get; init; } = -2;
        public AccidentalCharacter AccidentalCharacter { get; } = AccidentalCharacter.Flat;
        public AccidentalType AccidentalType { get; } = AccidentalType.HalfTone;
        public HalfToneAccidentalType HalfToneAccidentalType { get; } = HalfToneAccidentalType.DoubleFlat;

        internal DoubleFlatAccidental() { }
        public String GetRepresentation() => "𝄫";

    }
}
