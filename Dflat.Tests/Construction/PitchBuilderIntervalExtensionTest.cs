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
            Pitch expected = Pitches.OneLined().B().Natural().GetResult();

            var builder = Pitches.OneLined().G().Natural();
            var newNote = builder.TransposeBy(interval).GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        public void CorrectlyTransposesAugmentedThird()
        {
            Interval interval = new Interval(BaseInterval.Third, IntervalDirection.Up, IntervalModifier.Augmented);
            Pitch expected = Pitches.OneLined().B().Sharp().GetResult();

            var builder = Pitches.OneLined().G().Natural();
            var newNote = builder.TransposeBy(interval).GetResult();

            Assert.Equal(expected, newNote);
        }
    }
}
