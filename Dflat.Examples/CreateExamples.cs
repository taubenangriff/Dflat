using Dflat.Core;
//All Creation logic is in the Dflat.Construction namespace.
using Dflat.Construction;

namespace Dflat.Examples
{
    public class CreateExamples
    {
        public static void CreatePitch()
        {
            //Do Pitches.<Octave>().<BaseNote>().<Accidental>();
            //to instantiate a new PitchBuilder with the specified Pitch.
            PitchBuilder builder = Pitches.Small().F().Sharp();

            //Use GetResult() to get a pitch from the PitchBuilder;
            Pitch pitch = builder.GetResult();
        }

        public static void UsePitchBuilder()
        {
            //Each Operation from a Builder returns the Builder itself, so you can chain operations together.
            //This is not just true for the PitchBuilder but for all Builders
            PitchBuilder builder = Pitches.Small().F().Sharp();

            builder = builder.Sharpened().IncreaseBasePitch().Flattened();
        }

        public static void CreateNote()
        {
            //Use the NoteBuilder class to instantiate a new Note
            NoteBuilder builder = NoteBuilder.Create()
                //Use the WithPitch Method to freely set the Pitch of the Note using a PitchBuilder.
                .WithPitch(Pitches.Low().A().Natural())
                //Use the ModifyCurrentPitch Method to work with the current PitchBuilder
                .ModifyCurrentPitch(pitchBuilder => pitchBuilder.Sharpened());

            Note note = builder.GetResult();
        }

    }
}