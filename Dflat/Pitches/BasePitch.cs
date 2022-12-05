namespace Dflat.Pitches
{
    public enum BasePitch
    {
        C,
        D = 2,
        E = 4,
        F = 5,
        G = 7,
        A = 9,
        B = 11
    }

    public static class BasePitchExtensions
    {
        public static bool IsHalfToneToNext(this BasePitch pitch)
        {
            return pitch == BasePitch.E || pitch == BasePitch.B;
        }

        public static bool IsHalfToneToPrevious(this BasePitch pitch)
        {
            return pitch == BasePitch.F || pitch == BasePitch.C;
        }
        /// <summary>
        /// Gets the next BasePitch
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="NextOctave"></param>
        /// <returns></returns>
        public static BasePitch Next(this BasePitch pitch, out bool NextOctave)
        {
            int step = 2;
            if (pitch.IsHalfToneToNext())
                step = 1;

            int newPitch = (int)pitch + step;
            NextOctave = newPitch > 11;
            return (BasePitch)(newPitch % 12);
        }

        /// <summary>
        /// Gets the previous BasePitch
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="PreviousOctave"></param>
        /// <returns></returns>
        public static BasePitch Previous(this BasePitch pitch, out bool PreviousOctave)
        {
            int step = 2;
            if (pitch.IsHalfToneToPrevious())
                step = 1;

            int newPitch = (int)pitch - step;
            PreviousOctave = newPitch < 0;
            if (PreviousOctave)
                newPitch += 12;
            return (BasePitch)(newPitch);
        }
    }
}
