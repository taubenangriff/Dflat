using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.Core
{
    public enum BasePitch {
        C, 
        CSharp,
        D,
        DSharp,
        E,
        F,
        FSharp,
        G,
        GSharp,
        A,
        ASharp,
        B
    }

    public enum Interval { 
        Prime, 
        MinorSecond,
        MajorSecond,
        MinorThird,
        MajorThird,
        Fourth,
        Tritone,
        Fifth,
        MinorSixth,
        MajorSixth,
        MinorSeventh,
        MajorSeventh,
    }

    public class BaseInterval {
        public bool Downwards;
        public Interval Interval; 

        public BaseInterval(bool downwards, Interval interval) 
        {
            Downwards = downwards;
            Interval = interval; 
        }

        public override string ToString()
        {
            return Interval.ToString() + (Downwards ? " Down" : " Up");
        }
    }

    public class PitchClass
    {
        public BasePitch BasePitch { get; }

        public PitchClass(BasePitch pitch)
        {
            BasePitch = pitch;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not PitchClass other)
                return false;
            return other.BasePitch == this.BasePitch;
        }

        public override int GetHashCode() => BasePitch.GetHashCode();
    }
}
