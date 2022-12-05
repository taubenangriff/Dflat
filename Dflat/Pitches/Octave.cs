namespace Dflat.Pitches
{
    //all octaves that are playable on the piano.
    public enum Octave
    {
        Octocontra,
        SubContra,
        Contra,
        Great,
        Small,
        OneLine,
        TwoLine,
        ThreeLine,
        FourLine,
        FiveLine,
        SixLine
    }

    public static class OctaveExtensions
    {
        static Octave highestOctave = Enum.GetValues(typeof(Octave)).Cast<Octave>().Last();
        static Octave lowestOctave = Enum.GetValues(typeof(Octave)).Cast<Octave>().First();

        public static Octave NextOctave(this Octave octave)
        {
            if (octave == highestOctave)
                throw new InvalidOctaveException($"There is no Octave higher than {highestOctave}!");
            return (Octave)((int)octave + 1);
        }

        public static Octave PreviousOctave(this Octave octave)
        {
            if (octave == lowestOctave)
                throw new InvalidOctaveException($"There is no Octave lower than {highestOctave}!");
            return (Octave)((int)octave - 1);
        }

        public static String GetRepresentation(this Octave octave)
        {
            switch (octave)
            {
                case Octave.Octocontra : return "₋₁";
                case Octave.SubContra: return "₀";
                case Octave.Contra: return "₁";
                case Octave.Great: return "₂";
                case Octave.Small: return "₃";
                case Octave.OneLine: return "₄";
                case Octave.TwoLine: return "₅";
                case Octave.ThreeLine: return "₆";
                case Octave.FourLine: return "₇";
                case Octave.FiveLine: return "₈";
                case Octave.SixLine: return "₉";

                default: throw new InvalidOperationException();
            }
        }
    }
}
