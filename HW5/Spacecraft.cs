namespace HW5
{
    public abstract class Spacecraft : SpaceObject
    {
        public double Fuel { get; set; }
        public bool IsOperational { get; set; }

        protected Spacecraft(string name, double mass, double fuel, bool operational = true)
            : base(name, mass)
        {
            Fuel = fuel;
            IsOperational = operational;
        }

        protected Spacecraft(Spacecraft source) : base(source)
        {
            Fuel = source.Fuel;
            IsOperational = source.IsOperational;
        }
    }
}