using Dflat.Chords.Construction;
using Dflat.Intervals.Construction;

namespace Dflat.Intervals
{
    public static class ChordBuilderExtensions
    {
        public static ChordBuilder AddInterval(this ChordBuilder builder, IntervalBuilder intervalBuilder)
        {
            var interval = intervalBuilder.Build();
            builder.EnsureRootNoteExists();
            builder.AddPitch(builder.RootNote!.DeepClone().TransposeBy(interval));
            return builder;
        }
    }
}
