using Dflat.Core;

namespace Dflat.Construction
{
    public static class NoteConstructionExtensions
    {
        /// <summary>
        /// Shortcut for <see cref="NoteBuilder.Sharpened(bool)"/>: Loads the current note into a NoteBuilder, Sharpens it and returns the result.
        /// </summary>
        /// <param name="note"></param>
        /// <param name="PreferDoubleSharp"></param>
        /// <returns></returns>
        public static Note Sharpened(this Note note, bool PreferExtraSharp = false)
        {
            return NoteBuilder.Create(note)
                .ModifyCurrentPitch(
                    (pitch) => pitch.Sharpened(PreferExtraSharp))
                .GetResult();
        }

        public static Note Flattened(this Note note, bool PreferExtraFlat = false)
        {
            return NoteBuilder.Create(note)
                .ModifyCurrentPitch(
                    (pitch) => pitch.Flattened(PreferExtraFlat))
                .GetResult();
        }
    }
}
