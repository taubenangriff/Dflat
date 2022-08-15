namespace Dflat.Core
{
    public enum HalfToneAccidentalType
    { 
        Sharp, DoubleSharp, Flat, DoubleFlat
    }
    public interface IHalfToneAccidental : IAccidental
    {
        HalfToneAccidentalType HalfToneAccidentalType { get; }
        int PitchShift { get; init; }
    }
}
