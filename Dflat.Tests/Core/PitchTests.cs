using Dflat.Construction;
using Dflat.Core;
using Xunit;

namespace Dflat.Tests.Core
{
    public class PitchTests
    {
        [Fact]
        //Gb and F# are equivalent
        public void EquivalentPitch()
        {
            var pitch1 = Pitches.Small().G().Flat().GetResult();
            var pitch2 = Pitches.Small().F().Sharp().GetResult();

            Assert.True(pitch1.EnharmonicTo(pitch2));
        }

        [Fact]
        //Gb and F# are equivalent but not equal
        public void EquivalentMustNotMeanEqual()
        {
            var pitch1 = Pitches.Small().G().Flat().GetResult();
            var pitch2 = Pitches.Small().F().Sharp().GetResult();

            Assert.True(pitch1.EnharmonicTo(pitch2));
            Assert.False(pitch1.Equals(pitch2));
        }

        [Fact]
        public void PitchCompareEquivalentTo()
        {
            var pitch1 = Pitches.Small().G().Flat().GetResult();
            var pitch2 = Pitches.Small().F().Sharp().GetResult();

            Assert.Equal(0, pitch1.CompareEnharmonicTo(pitch2));
        }

        [Fact]
        public void PitchCompareEquivalentToMustNotMeanCompareTo()
        {
            var pitch1 = Pitches.Small().G().Flat().GetResult();
            var pitch2 = Pitches.Small().F().Sharp().GetResult();

            Assert.Equal(0, pitch1.CompareEnharmonicTo(pitch2));
            Assert.NotEqual(0, pitch1.CompareTo(pitch2));
        }
    }
}
