using Dflat.GeneralizedIntervalSystems.Predefined;
using Dflat.Pitches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dflat.Examples
{
    public class GISExamples
    {
        public static void GISIntervalTest()
        {
            var _ = MainGIS.ModalGIS.GetIntervalAsBuilder(
                MainPitches.OneLined().E().Natural().Build(),
                MainPitches.OneLined().F().Natural().Build()
            );
            Console.WriteLine(_);
        }
    }
}
