using Xunit;

using Dflat.Construction;
using Dflat.Core;

namespace Dflat.Tests.Construction
{
    public class PitchBuilderTests
    {
        [Fact]
        //Increases C1 to D1
        public void IncreasesPitchWithoutOctaveFlip()
        {
            Pitch expected = Pitches.OneLined().D().Natural().GetResult();

            var builder = Pitches.OneLined().C().Natural();
            var newNote = builder.IncreaseBasePitch().GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Increases B1 to C2
        public void IncreasesPitchWithOctaveFlip()
        {
            Pitch expected = Pitches.TwoLined().C().Natural().GetResult();

            var builder = Pitches.OneLined().B().Natural();
            var newNote = builder.IncreaseBasePitch().GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Decreases D1 to C1
        public void DecreasesPitchWithoutOctaveFlip()
        {
            Pitch expected = Pitches.OneLined().C().Natural().GetResult();

            var builder = Pitches.OneLined().D().Natural();
            var newNote = builder.DecreaseBasePitch().GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Decreases C2 to B1.
        public void DecreasesPitchWithOctaveFlip()
        {
            Pitch expected = PitchBuilder.Create(BasePitch.B, Octave.OneLine).GetResult();

            var builder = Pitches.TwoLined().C().Natural();
            var newNote = builder.DecreaseBasePitch().GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Sharpens Cx to D#
        public void SharpensDoubleSharpCorrectly()
        {
            Pitch expected = Pitches.OneLined().D().Sharp().GetResult();

            var builder = Pitches.OneLined().C().DoubleSharp();
            var newNote = builder.Sharpened()
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Sharpens C# to Cx when PreferDoubleSharp is set on PitchBuilder.Sharpened()
        public void SharpensSharpToDoubleSharpOnRequest()
        {
            Pitch expected = Pitches.OneLined().C().DoubleSharp().GetResult();

            var builder = Pitches.OneLined().C().Sharp();
            var newNote = builder.Sharpened(PreferExtraSharp: true)
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Flattens Db to Dbb if PreferExtraFlat is set on PitchBuilder.Flattened()
        public void FlattensFlatToDoubleFlatOnRequest()
        {
            Pitch expected = Pitches.OneLined().D().DoubleFlat().GetResult();

            var builder = Pitches.OneLined().D().Flat();
            var newNote = builder.Flattened(PreferExtraFlats: true)
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //C# gets sharpened to D when PreferDoubleSharp is false on PitchBuilder.Sharpened()
        public void DoesNotSharpenDoubleSharpWithoutRequest()
        {
            Pitch expected = Pitches.OneLined().D().Natural().GetResult();

            var builder = Pitches.OneLined().C().Sharp();
            var newNote = builder.Sharpened(PreferExtraSharp: false)
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Db gets flattened to C without PreferExtraSharp
        public void DoesNotFlattenDoubleFlatWithoutRequest()
        {
            Pitch expected = Pitches.OneLined().C().Natural().GetResult();

            var builder = Pitches.OneLined().D().Flat();
            var newNote = builder.Flattened()
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //E gets sharpened to F when nothing else is requested
        public void DoesNotSharpenHalfToneWithoutRequest()
        {
            Pitch expected = Pitches.OneLined().F().Natural().GetResult();

            var builder = Pitches.OneLined().E().Natural();
            var newNote = builder.Sharpened()
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //F gets flattened to E when nothing else is requested 
        public void DoesNotFlattenHalfToneWithoutRequest()
        {
            Pitch expected = Pitches.OneLined().E().Natural().GetResult();

            var builder = Pitches.OneLined().F().Natural();
            var newNote = builder.Flattened().GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //E gets sharpened to E# if requested
        public void SharpensHalfToneOnRequest()
        {
            Pitch expected = Pitches.OneLined().E().Sharp().GetResult();

            var builder = Pitches.OneLined().E().Natural();
            var newNote = builder.Sharpened(PreferExtraSharp: true)
                                .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //F gets flattened to Fb if requested
        public void FlattensHalfToneOnRequest()
        {
            Pitch expected = Pitches.OneLined().F().Flat().GetResult();

            var builder = Pitches.OneLined().F().Natural();
            var newNote = builder.Flattened(PreferExtraFlats: true).GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //sharpened turns B1 into C2
        public void SharpenedFlipsOctaveWhenNeeded()
        {
            Pitch expected = Pitches.TwoLined().C().Natural().GetResult();

            PitchBuilder builder = Pitches.OneLined().B().Natural();
            var newNote = builder.Sharpened(PreferExtraSharp: false)
                                 .GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //Flattened turns C2 into B1
        public void FlattenedFlipsOctaveWhenNeeded()
        {
            Pitch expected = Pitches.OneLined().B().Natural().GetResult();

            var builder = Pitches.TwoLined().C().Natural();
            var newNote = builder.Flattened().GetResult();

            Assert.Equal(expected, newNote);
        }

        [Fact]
        //sharpen turns C1 into C#
        public void SharpenedAddsSharpToNoAccidentalWithWholeToneNext()
        {
            Pitch expected = Pitches.OneLined().C().Sharp().GetResult();

            var builder = Pitches.OneLined().C().Natural();
            var newNote = builder.Sharpened()
                                  .GetResult();
            
            Assert.Equal(expected, newNote);
        }

        [Fact]
        //flatten turns A to Ab
        public void FlattenedAddsFlatToNoAccidentalWithWholeTonePrev()
        {
            Pitch expected = Pitches.OneLined().A().Flat().GetResult();

            var builder = Pitches.OneLined().A().Natural();
            var newNote = builder.Flattened().GetResult();

            Assert.Equal(expected, newNote);
        }
    }
}
