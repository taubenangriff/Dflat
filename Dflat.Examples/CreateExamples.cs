using Dflat.Chords;
using Dflat.Core;
using Dflat.Durations;
using Dflat.Intervals;
using Dflat.Pitches;

namespace Dflat.Examples
{
    public class CreateExamples
    {
        public static void CreatePitch()
        {
            //Do Pitches.<Octave>().<BaseNote>().<Accidental>();
            //to instantiate a new PitchBuilder with the specified Pitch.
            PitchBuilder builder = MainPitches.Small().F().Sharp();

            //Use Build() to get a pitch from the PitchBuilder;
            Pitch pitch = builder.Build();
        }

        public static void CreateDuration()
        {
            //Use Durations.<BaseLength>().<Dots?>();
            //to instantiate a new DurationBuilder with the specified Duration.
            DurationBuilder builder = MainDurations.Quarter().WithDot();
            Duration duration = builder.Build();
        }

        public static void UsePitchBuilder()
        {
            //Each Operation from a Builder returns the Builder itself, so you can chain operations together.
            PitchBuilder builder = MainPitches.Small().F().Sharp();

            builder = builder.Sharpened().IncreaseBasePitch().Flattened();
        }

        public static void CreateNote()
        {
            //Use the NoteBuilder class to instantiate a new Note
            NoteBuilder builder = NoteBuilder.Create()
                //Use the WithPitch Method to freely set the Pitch of the Note using a PitchBuilder.
                .WithPitch(MainPitches.Low().A().Natural())
                //Use the ModifyCurrentPitch Method to work with the current PitchBuilder
                .ModifyCurrentPitch(pitchBuilder => pitchBuilder.Sharpened())
                //Use WithDuration Method to freely set the duration
                .WithDuration(MainDurations.Quarter().WithDot())
                //Use ModifyDuration Method to work with the current DurationBuilder
                .ModifyDuration( durationBuilder => durationBuilder.WithoutDot());

            Note note = builder.Build();
        }

        public static void CreateChord()
        {
            ChordBuilder builder = ChordBuilder.Create()
                //Add A, C# and E to the chord
                .AddPitch(MainPitches.Small().A().Natural())
                .AddPitch(MainPitches.OneLined().C().Sharp())
                .AddPitch(MainPitches.OneLined().E().Natural())
                //Set duration to be a quarter note.
                .WithDuration(MainDurations.Quarter().WithoutDot());

            Chord c = builder.Build();
        }

        public static void CreateChordWithRootAndIntervals()
        {
            ChordBuilder builder = ChordBuilder.Create()
                .WithRootNote(MainPitches.Small().A().Natural())
                //Add diminished ninth (Bbb to the chord)
                .AddInterval(MainIntervals.Diminished().Ninth().Up());

            var chord = builder.Build();

            Console.WriteLine(String.Join(" ", chord.Pitches.Select(x => x.ToString())));
        }

        public static void CreateDominantCChord()
        {
            var triadBuilder = Triads.MajorTriadOn(MainPitches.Low().C().Natural());
            triadBuilder.AddInterval(MainIntervals.Minor().Seventh().Up());
            
            var chord = triadBuilder.Build();

            Console.WriteLine(String.Join(" ", chord.Pitches.Select(x => x.ToString())));
        }

    }
}