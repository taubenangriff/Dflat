namespace Dflat.Intervals
{
    public enum IntervalModifier
    {
        QuadrupleDiminished,
        TripleDiminished,
        DoubleDiminished,
        Diminished,
        Major,
        Minor,
        Augmented,
        DoubleAugmented,
        TripleAugmented,
        QuadrupleAugmented
    }

    public static class IntervalModifierExtensions
    {
        public static IntervalModifier GetPrev(this IntervalModifier modifier)
        {
            if (modifier == IntervalModifier.QuadrupleDiminished)
                throw new InvalidOperationException("Quadruple Diminished is the lowest possible modifier for intervals");

            return (IntervalModifier)((int)modifier) - 1;
        }

        public static IntervalModifier GetNext(this IntervalModifier modifier)
        {
            if (modifier == IntervalModifier.QuadrupleAugmented)
                throw new InvalidOperationException("Quadruple Augmented is the highest possible modifier for intervals");

            return (IntervalModifier)((int)modifier) + 1;
        }

        public static IntervalModifier GetModified(this IntervalModifier modifier, int by)
        {
            int modified = ((int)modifier) + by;
            if (modified < 0)
                throw new InvalidOperationException("Quadruple Diminished is the lowest possible modifier for intervals");
            if (modified > 9)
                throw new InvalidOperationException("Quadruple Augmented is the highest possible modifier for intervals");

            return (IntervalModifier)modified;
        }
    }
}
