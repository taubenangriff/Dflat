using Dflat.Core;
using Dflat.Intervals;
using Dflat.Pitches;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.Scales
{
    public class Scale : IEnumerable<Pitch>
    {
        public Pitch BasePitch { get; }

        public IEnumerable<Interval> ScaleDegrees { get => throw new NotImplementedException("Scale as Intervals not yet implemented"); set => throw new NotImplementedException("Scale as Intervals not yet implemented");
    }
        public IEnumerable<Pitch> Pitches { get; }

        internal Scale(
            Pitch basePitch,
            IEnumerable<Pitch> pitches)
        {
            BasePitch = basePitch;
            ScaleDegrees = Enumerable.Empty<Interval>();
            Pitches = pitches;
        }

        public bool IsPartOfScale(Pitch p) => Pitches.Any(x => x.Equals(p));

        public bool IsAnyEnharmonicEquivPartOfScale(Pitch p) => Pitches.Any(x => x.IsEnharmonicTo(p));

        public IEnumerator<Pitch> GetEnumerator() => Pitches.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Pitches.GetEnumerator();
    }
}
