using Dflat.Core;

var e = new PitchClass(BasePitch.E);
var c = new PitchClass(BasePitch.C);

var gis = new PitchClassGIS();
var interval = gis.GetInterval(c, e);
Console.WriteLine(interval);