using Dflat.Core;
using Dflat.Intervals;
using Dflat.Pitches;
using Xunit;

namespace Dflat.Tests.Construction
{
    public class PitchBuilderIntervalExtensionTest
    {
        [Fact]
        public void CorrectlyTransposesMajorThird()
        {
            Interval interval = new Interval(BaseInterval.Third, IntervalDirection.Up);
            Pitch expected = MainPitches.OneLined().B().Natural().Build();

            var builder = MainPitches.OneLined().G().Natural();
            var newNote = builder.TransposeBy(interval).Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        public void CorrectlyTransposesAugmentedThird()
        {
            Interval interval = new Interval(BaseInterval.Third, IntervalDirection.Up, IntervalModifier.Augmented);
            Pitch expected = MainPitches.OneLined().B().Sharp().Build();

            var builder = MainPitches.OneLined().G().Natural();
            var newNote = builder.TransposeBy(interval).Build();

            Assert.Equal(expected, newNote);
        }
    }
}
