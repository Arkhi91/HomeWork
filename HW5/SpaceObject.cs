namespace HW5
{
    public abstract class SpaceObject : IMyCloneable<SpaceObject>, ICloneable
    {
        public string Name { get; set; }
        public double Mass { get; set; } //думаю что лучше все делать в тоннах, чтобы цмфры были более-менее адекватные
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        protected SpaceObject(string name, double mass, double x = 0, double y = 0, double z = 0)
        {
            Name = name;
            Mass = mass;
            X = x; Y = y; Z = z;
        }

        protected SpaceObject(SpaceObject source) //перегрузка конструктора для копирования
        {
            Name = source.Name;
            Mass = source.Mass;
            X = source.X;
            Y = source.Y;
            Z = source.Z;
        }

        public abstract SpaceObject Clone();

        object ICloneable.Clone() => Clone();
    }
}