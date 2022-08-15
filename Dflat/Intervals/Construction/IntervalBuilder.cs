using Dflat.Intervals;
using Dflat.Core;

namespace Dflat.Intervals.Construction
{
    public class IntervalBuilder : IBuilder<Interval>
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
            throw new NotImplementedException();
        }

        public static IntervalBuilder Create(Interval i)
        {
            return new IntervalBuilder(i.BaseInterval, i.Modifier, i.Direction);
        }

        public Interval GetResult()
        {
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

        public IntervalBuilder Augment()
        { 
            Modifier = IntervalModifier.Augmented;
            return this;
        }

        public IntervalBuilder Diminish()
        {
            Modifier = IntervalModifier.Diminished;
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
