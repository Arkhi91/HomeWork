namespace HW5
{
    public class Probe : Spacecraft
    {
        public string Mission { get; set; }

        public Probe(string name, double mass, double fuel, string mission)
            : base(name, mass, fuel)
        {
            Mission = mission;
        }

        private Probe(Probe source) : base(source)
        {
            Mission = source.Mission;
        }

        public override SpaceObject Clone() => new Probe(this);
    }
}