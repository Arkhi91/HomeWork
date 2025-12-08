namespace HW5
{
    public class Starship : Spacecraft
    {
        public int CrewCapacity { get; set; }
        public int CargoCapacity { get; set; }

        public Starship(string name, double mass, double fuel, int crew, int cargo)
            : base(name, mass, fuel)
        {
            CrewCapacity = crew;
            CargoCapacity = cargo;
        }

        public Starship(Starship source) : base(source)
        {
            CrewCapacity = source.CrewCapacity;
            CargoCapacity = source.CargoCapacity;
        }

        public override SpaceObject Clone() => new Starship(this);
    }
}