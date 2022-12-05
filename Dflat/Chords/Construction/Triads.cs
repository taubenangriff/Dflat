using Dflat.Core;
using Dflat.Intervals;
using Dflat.Pitches;

namespace Dflat.Chords
{
    public class Triads
    {
        public static ChordBuilder MajorTriadOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddMajorTriadOn(pitch)
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder MinorTriadOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddMinorTriadOn(pitch)
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder DiminishedTriadOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddDiminishedTriadOn(pitch)
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder AugmentedTriadOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddAugmentedTriadOn(pitch)
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder DominantSeventhOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddMajorTriadOn(pitch)
                .AddInterval(MainIntervals.Minor().Seventh().Up())
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder MajorSeventhOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddMajorTriadOn(pitch)
                .AddInterval(MainIntervals.Major().Seventh().Up())
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder FullDiminishedTriadOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddDiminishedTriadOn(pitch)
                .AddInterval(MainIntervals.Diminished().Seventh().Up())
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder HalfDiminishedTriadOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddDiminishedTriadOn(pitch)
                .AddInterval(MainIntervals.Minor().Seventh().Up())
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder GermanSixthOn(PitchBuilder pitch)
        {
            return TriadBuilder.Create()
                .AddMajorTriadOn(pitch)
                .AddInterval(MainIntervals.Augmented().Sixth().Up())
                .WithRootNote(pitch, false);
        }

        public static ChordBuilder FrenchSixthOn(PitchBuilder pitch)
        {
            return ChordBuilder.Create()
                .WithRootNote(pitch, false)
                .AddPitch(pitch)
                .AddInterval(MainIntervals.Major().Third().Up())
                .AddInterval(MainIntervals.Augmented().Fourth().Up())
                .AddInterval(MainIntervals.Augmented().Sixth().Up());
        }

        public static ChordBuilder ItalianSixthOn(PitchBuilder pitch)
        {
            return ChordBuilder.Create()
                .WithRootNote(pitch, false)
                .AddPitch(pitch)
                .AddInterval(MainIntervals.Major().Third().Up())
                .AddInterval(MainIntervals.Augmented().Sixth().Up());
        }
    }
}
