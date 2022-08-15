namespace Dflat.Core
{
    /// <summary>
    /// Represents an Accidental that is not required to be in a half tone system.
    /// </summary>
    public interface IFluentAccidental : IAccidental
    {
        float PitchShift { get; init; }
    }

    public static class FluentAccidentalExtensions
    {
        public static AccidentalCharacter GetAccidentalCharacter(this IFluentAccidental accidental)
        {
            switch (accidental.PitchShift)
            {
                case > 0: return AccidentalCharacter.Sharp;
                case < 0: return AccidentalCharacter.Flat;
                default: return AccidentalCharacter.Natural;
            }
        }
    }
}
