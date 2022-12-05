using Dflat.Core;
using Dflat.Pitches;
using Xunit;

namespace Dflat.Tests.Core
{
    public class PitchTests
    {
        [Fact]
        //Gb and F# are equivalent
        public void EquivalentPitch()
        {
            var pitch1 = MainPitches.Small().G().Flat().Build();
            var pitch2 = MainPitches.Small().F().Sharp().Build();

            Assert.True(pitch1.IsEnharmonicTo(pitch2));
        }

        [Fact]
        //Gb and F# are equivalent but not equal
        public void EquivalentMustNotMeanEqual()
        {
            var pitch1 = MainPitches.Small().G().Flat().Build();
            var pitch2 = MainPitches.Small().F().Sharp().Build();

            Assert.True(pitch1.IsEnharmonicTo(pitch2));
            Assert.False(pitch1.Equals(pitch2));
        }

        [Fact]
        public void PitchCompareEquivalentTo()
        {
            var pitch1 = MainPitches.Small().G().Flat().Build();
            var pitch2 = MainPitches.Small().F().Sharp().Build();

            Assert.Equal(0, pitch1.CompareTo(pitch2));
        }

        [Fact]
        public void PitchCompareEquivalentToMustNotMeanCompareTo()
        {
            var pitch1 = MainPitches.Small().G().Flat().Build();
            var pitch2 = MainPitches.Small().F().Sharp().Build();

            Assert.Equal(0, pitch1.CompareTo(pitch2));
            Assert.False(pitch1.Equals(pitch2));
        }

        [Fact]
        public void PitchAccidentalsCorrectComparison()
        {
            var pitch1 = MainPitches.Small().G().DoubleFlat().Build();
            var pitch2 = MainPitches.Small().F().DoubleSharp().Build();

            int compared = pitch1.CompareTo(pitch2);
            Assert.True(compared < 0);
        }
    }
}
