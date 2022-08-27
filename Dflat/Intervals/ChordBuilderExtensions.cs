using Dflat.Chords.Construction;

namespace Dflat.Intervals
{
    public static class ChordBuilderExtensions
    {
        public static ChordBuilder AddInterval(this ChordBuilder builder, Interval interval)
        {
            builder.EnsureRootNoteExists();
            builder.AddPitch(builder.RootNote!.DeepClone().TransposeBy(interval));
            return builder;
        }
    }
}
