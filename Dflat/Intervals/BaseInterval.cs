namespace Dflat.Intervals
{
    public enum BaseInterval
    {
        Unison, 
        Second = 2,
        Third = 4,
        Fourth = 5,
        Fifth = 7,
        Sixth = 9,
        Seventh = 11,
        Octave = 12,
        Ninth = 14,
        Tenth = 16,
        Eleventh = 17,
        Twelfth = 19,
        Thirteenth = 21,
        Fourteenth = 23,
        Fifteenth = 24
    }

    public static class BaseIntervalExtensions
    {
        public static bool IsPerfect(this BaseInterval baseInterval)
        {
            switch (baseInterval)
            { 
                case BaseInterval.Unison:
                case BaseInterval.Fourth:
                case BaseInterval.Fifth:
                case BaseInterval.Octave:
                case BaseInterval.Eleventh:
                case BaseInterval.Twelfth:
                case BaseInterval.Fifteenth:
                    return true;
                default:
                    return false;
            }
        }
    }
}
