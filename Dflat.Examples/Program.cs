using Dflat.Core;

var e = new PitchClass(BasePitch.E);
var c = new PitchClass(BasePitch.C);
var g = new PitchClass(BasePitch.G);

var gis = new PitchClassGIS();
var interval = gis.GetInterval(e, c);
Console.WriteLine(interval);