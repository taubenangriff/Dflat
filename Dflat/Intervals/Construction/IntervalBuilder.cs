using Dflat.Core;

namespace Dflat.Intervals
{
    public class IntervalBuilder : IBuilder<Interval, IntervalBuilder>
    {
        public BaseInterval BaseInterval { get; private set; }
        public IntervalModifier Modifier { get; private set; }
        public IntervalDirection Direction { get; private set; }

        private IntervalBuilder(BaseInterval interval,
            IntervalModifier modifier,
            IntervalDirection direction) 
        {
            BaseInterval = interval;
            Modifier = modifier;
            Direction = direction;
        }

        public static IntervalBuilder Create()
        {
            return new IntervalBuilder(BaseInterval.Unison, IntervalModifier.Major, IntervalDirection.Up);
        }

        public IntervalBuilder DeepClone() => IntervalBuilder.Create(this.Build());

        public static IntervalBuilder Create(Interval i)
        {
            return new IntervalBuilder(i.BaseInterval, i.Modifier, i.Direction);
        }

        public Interval Build()
        {
            if (BaseInterval.IsPerfect() && Modifier == IntervalModifier.Major)
                throw new InvalidOperationException("A perfect interval cannot be major!");
            if (BaseInterval.IsPerfect() && Modifier == IntervalModifier.Minor)
                throw new InvalidOperationException("A perfect interval cannot be minor!");
            return new Interval(BaseInterval, Direction, Modifier);
        }

        public IntervalBuilder Downwards()
        {
            Direction = IntervalDirection.Down;
            return this;
        }

        public IntervalBuilder Upwards()
        {
            Direction = IntervalDirection.Up;
            return this;
        }

        public IntervalBuilder FlipDirection()
        { 
            Direction = Direction == IntervalDirection.Up ? IntervalDirection.Down : IntervalDirection.Up;
            return this;
        }

        public IntervalBuilder AsAugmented()
        { 
            Modifier = IntervalModifier.Augmented;
            return this;
        }

        public IntervalBuilder AsDiminished()
        {
            Modifier = IntervalModifier.Diminished;
            return this;
        }

        public IntervalBuilder Diminish()
        {
            Modifier = Modifier.GetPrev();
            return this;
        }

        public IntervalBuilder Augment()
        {
            Modifier = Modifier.GetNext();
            return this;
        }

        public IntervalBuilder AsMinor()
        {
            Modifier = IntervalModifier.Minor;
            return this;
        }

        public IntervalBuilder AsMajor()
        {
            Modifier = IntervalModifier.Major;
            return this;
        }

        public IntervalBuilder WithBaseInterval(BaseInterval interval)
        {
            BaseInterval = interval;
            return this;
        }

        public IntervalBuilder WithModifier(IntervalModifier modifier)
        {
            Modifier = modifier;
            return this;
        }

    }
}
