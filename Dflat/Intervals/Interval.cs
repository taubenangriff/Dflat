namespace Dflat.Intervals
{
    public class Interval
    {
        public BaseInterval BaseInterval { get; }
        public IntervalDirection Direction { get; }
        public IntervalModifier Modifier { get; }

        public bool IsPerfect { get; }

        public Interval(
            BaseInterval baseInterval, 
            IntervalDirection intervalDirection,
            IntervalModifier modifier = IntervalModifier.Major)
        {
            BaseInterval = baseInterval;
            Direction = intervalDirection;
            Modifier = modifier;
            IsPerfect = baseInterval.IsPerfect();
        }

        public int GetHalfSteps()
        {
            return GetBaseHalfSteps() + GetModifierHalfSteps();
        }

        public int GetBaseHalfSteps()
        {
            int self = (int)BaseInterval;
            int directionfactor = Direction.Equals(IntervalDirection.Down) ? -1 : 1;

            return self*directionfactor;
        }

        public int GetModifierHalfSteps()
        {
            int directionfactor = Direction.Equals(IntervalDirection.Down) ? -1 : 1;
            switch (Modifier)
            {
                case IntervalModifier.Augmented:
                    return (1) * directionfactor;
                case IntervalModifier.Diminished when IsPerfect:
                    return (-1) * directionfactor;
                case IntervalModifier.Diminished when !IsPerfect:
                    return (-2) * directionfactor;
                case IntervalModifier.Minor when !IsPerfect:
                    return (-1) * directionfactor;
            }
            throw new InvalidProgramException("Unsupported IntervalModifier");
        }
    }
}
