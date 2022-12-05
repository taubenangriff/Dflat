using Xunit;

using Dflat.Core;
using Dflat.Pitches;

namespace Dflat.Tests.Construction
{
    public class PitchBuilderTests
    {
        [Fact]
        //Increases C1 to D1
        public void IncreasesPitchWithoutOctaveFlip()
        {
            Pitch expected = MainPitches.OneLined().D().Natural().Build();

            var builder = MainPitches.OneLined().C().Natural();
            var newNote = builder.IncreaseBasePitch().Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Increases B1 to C2
        public void IncreasesPitchWithOctaveFlip()
        {
            Pitch expected = MainPitches.TwoLined().C().Natural().Build();

            var builder = MainPitches.OneLined().B().Natural();
            var newNote = builder.IncreaseBasePitch().Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Decreases D1 to C1
        public void DecreasesPitchWithoutOctaveFlip()
        {
            Pitch expected = MainPitches.OneLined().C().Natural().Build();

            var builder = MainPitches.OneLined().D().Natural();
            var newNote = builder.DecreaseBasePitch().Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Decreases C2 to B1.
        public void DecreasesPitchWithOctaveFlip()
        {
            Pitch expected = PitchBuilder.Create(BasePitch.B, Octave.OneLine).Build();

            var builder = MainPitches.TwoLined().C().Natural();
            var newNote = builder.DecreaseBasePitch().Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Sharpens Cx to D#
        public void SharpensDoubleSharpCorrectly()
        {
            Pitch expected = MainPitches.OneLined().D().Sharp().Build();

            var builder = MainPitches.OneLined().C().DoubleSharp();
            var newNote = builder.Sharpened()
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Sharpens C# to Cx when PreferDoubleSharp is set on PitchBuilder.Sharpened()
        public void SharpensSharpToDoubleSharpOnRequest()
        {
            Pitch expected = MainPitches.OneLined().C().DoubleSharp().Build();

            var builder = MainPitches.OneLined().C().Sharp();
            var newNote = builder.Sharpened(PreferExtraSharp: true)
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Flattens Db to Dbb if PreferExtraFlat is set on PitchBuilder.Flattened()
        public void FlattensFlatToDoubleFlatOnRequest()
        {
            Pitch expected = MainPitches.OneLined().D().DoubleFlat().Build();

            var builder = MainPitches.OneLined().D().Flat();
            var newNote = builder.Flattened(PreferExtraFlats: true)
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //C# gets sharpened to D when PreferDoubleSharp is false on PitchBuilder.Sharpened()
        public void DoesNotSharpenDoubleSharpWithoutRequest()
        {
            Pitch expected = MainPitches.OneLined().D().Natural().Build();

            var builder = MainPitches.OneLined().C().Sharp();
            var newNote = builder.Sharpened(PreferExtraSharp: false)
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Db gets flattened to C without PreferExtraSharp
        public void DoesNotFlattenDoubleFlatWithoutRequest()
        {
            Pitch expected = MainPitches.OneLined().C().Natural().Build();

            var builder = MainPitches.OneLined().D().Flat();
            var newNote = builder.Flattened()
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //E gets sharpened to F when nothing else is requested
        public void DoesNotSharpenHalfToneWithoutRequest()
        {
            Pitch expected = MainPitches.OneLined().F().Natural().Build();

            var builder = MainPitches.OneLined().E().Natural();
            var newNote = builder.Sharpened()
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //F gets flattened to E when nothing else is requested 
        public void DoesNotFlattenHalfToneWithoutRequest()
        {
            Pitch expected = MainPitches.OneLined().E().Natural().Build();

            var builder = MainPitches.OneLined().F().Natural();
            var newNote = builder.Flattened().Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //E gets sharpened to E# if requested
        public void SharpensHalfToneOnRequest()
        {
            Pitch expected = MainPitches.OneLined().E().Sharp().Build();

            var builder = MainPitches.OneLined().E().Natural();
            var newNote = builder.Sharpened(PreferExtraSharp: true)
                                .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //F gets flattened to Fb if requested
        public void FlattensHalfToneOnRequest()
        {
            Pitch expected = MainPitches.OneLined().F().Flat().Build();

            var builder = MainPitches.OneLined().F().Natural();
            var newNote = builder.Flattened(PreferExtraFlats: true).Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //sharpened turns B1 into C2
        public void SharpenedFlipsOctaveWhenNeeded()
        {
            Pitch expected = MainPitches.TwoLined().C().Natural().Build();

            PitchBuilder builder = MainPitches.OneLined().B().Natural();
            var newNote = builder.Sharpened(PreferExtraSharp: false)
                                 .Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Flattened turns C2 into B1
        public void FlattenedFlipsOctaveWhenNeeded()
        {
            Pitch expected = MainPitches.OneLined().B().Natural().Build();

            var builder = MainPitches.TwoLined().C().Natural();
            var newNote = builder.Flattened().Build();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //sharpen turns C1 into C#
        public void SharpenedAddsSharpToNoAccidentalWithWholeToneNext()
        {
            Pitch expected = MainPitches.OneLined().C().Sharp().Build();

            var builder = MainPitches.OneLined().C().Natural();
            var newNote = builder.Sharpened()
                                  .Build();
            
            Assert.Equal(expected, newNote);
        }

        [Fact]
        //flatten turns A to Ab
        public void FlattenedAddsFlatToNoAccidentalWithWholeTonePrev()
        {
            Pitch expected = MainPitches.OneLined().A().Flat().Build();

            var builder = MainPitches.OneLined().A().Natural();
            var newNote = builder.Flattened().Build();

            Assert.Equal(expected, newNote);
        }

    }
}
