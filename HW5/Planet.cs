namespace HW5
{
    public class Planet : CelestialBody
    {
        public bool HasAtmosphere { get; set; }
        public double OrbitalPeriod { get; set; }

        public Planet(string name, double mass, double radius, double temp,
                      bool hasAtmosphere, double orbitalPeriod)
            : base(name, mass, radius, temp)
        {
            HasAtmosphere = hasAtmosphere;
            OrbitalPeriod = orbitalPeriod;
        }

        public Planet(Planet source) : base(source)
        {
            HasAtmosphere = source.HasAtmosphere;
            OrbitalPeriod = source.OrbitalPeriod;
        }

        public override SpaceObject Clone() => new Planet(this);
    }
}