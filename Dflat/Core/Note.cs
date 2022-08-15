using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.Core
{
    /// <summary>
    /// A note is immutable. Every change to a note will have to return a new note!
    /// </summary>
    public sealed class Note
    {
        public Pitch Pitch { get; init; }

        internal Note(Pitch pitch)
        {
            Pitch = pitch;
        }
    }
}
