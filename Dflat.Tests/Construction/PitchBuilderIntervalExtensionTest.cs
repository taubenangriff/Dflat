using Dflat.Core.Construction;
using Dflat.Core;
using Dflat.Intervals;

using Xunit;

namespace Dflat.Tests.Construction
{
    public class PitchBuilderIntervalExtensionTest
    {
        [Fact]
        public void CorrectlyTransposesMajorThird()
        {
            Interval interval = new Interval(BaseInterval.Third, IntervalDirection.Up);
            Pitch expected = Pitches.OneLined().B().Natural().Build();

            var builder = Pitches.OneLined().G().Natural();
            var newNote = builder.TransposeBy(interval).Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        public void CorrectlyTransposesAugmentedThird()
        {
            Interval interval = new Interval(BaseInterval.Third, IntervalDirection.Up, IntervalModifier.Augmented);
            Pitch expected = Pitches.OneLined().B().Sharp().Build();

            var builder = Pitches.OneLined().G().Natural();
            var newNote = builder.TransposeBy(interval).Build();

            Assert.Equal(expected, newNote);
        }
    }
}
