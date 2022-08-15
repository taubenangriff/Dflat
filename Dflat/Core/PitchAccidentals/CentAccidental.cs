using System.Text;

namespace Dflat.Core
{
    public class CentAccidental : IFluentAccidental
    {
        public float PitchShift { get; init; }

        public AccidentalCharacter AccidentalCharacter { get => this.GetAccidentalCharacter(); }

        public AccidentalType AccidentalType => AccidentalType.Fluent;

        private int _cents;
        internal CentAccidental(int cents)
        {
            PitchShift = 1f / cents;
            _cents = cents;
        }

        public static CentAccidental? FromCents(int cents)
        {
            if (cents == 0)
                return null;
            if (cents > 100 || cents < -100)
                throw new ArgumentException("Cent offset must be in a range of -100 to +100");
            return new CentAccidental(cents);
        }

        public String GetRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            switch (this.GetAccidentalCharacter())
            {
                case AccidentalCharacter.Sharp: sb.Append("↑"); break;
                case AccidentalCharacter.Flat: sb.Append("↓"); break;
            }
            sb.Append(_cents);
            return sb.ToString();
        }
    }
}
