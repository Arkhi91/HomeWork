namespace HW5
{
    public class Star : CelestialBody
    {
        public string SpectralClass { get; set; }

        public Star(string name, double mass, double radius, double temp, string spectralClass)
            : base(name, mass, radius, temp)
        {
            SpectralClass = spectralClass;
        }

        private Star(Star source) : base(source)
        {
            SpectralClass = source.SpectralClass;
        }

        public override SpaceObject Clone() => new Star(this);
    }
}