namespace Dflat.Core
{
    public class InvalidOctaveException : Exception
    {
        public InvalidOctaveException()
            : base("pitch is outside of the supported range. ")
        { }

        public InvalidOctaveException(string message) : base("pitch is outside of the supported range. " + message) 
        { }

        public InvalidOctaveException(string message, Exception inner) : base("pitch is outside of the supported range. " + message, inner)
        { 
        
        }
    }
}
