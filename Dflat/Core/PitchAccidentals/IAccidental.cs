namespace Dflat.Core
{
    public enum AccidentalCharacter { Sharp, Flat, Natural }

    public enum AccidentalType { Fluent, HalfTone }

    /// <summary>
    /// Represents a Shift in pitch
    /// </summary>
    public interface IAccidental
    {
        public AccidentalCharacter AccidentalCharacter { get; }
        public AccidentalType AccidentalType { get; }
        String GetRepresentation();
    }
}
