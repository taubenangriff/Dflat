﻿using Dflat.Pitches;

namespace Dflat.Intervals
{
    public static class PitchExtensions
    {
        public static Pitch TransposeBy(this Pitch pitch, Interval interval)
        {
            var builder = PitchBuilder.Create(pitch);
            return builder.TransposeBy(interval).Build();
        }
    }
}
