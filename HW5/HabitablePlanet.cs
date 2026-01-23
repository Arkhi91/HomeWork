namespace HW5
{
    public class HabitablePlanet : Planet
    {
        public int Population { get; set; }
        public string DominantSpecies { get; set; }

        public HabitablePlanet(string name, double mass, double radius,
                              int population, string species = "Human")
            : base(name, mass, radius, 288, true, 365)
        {
            Population = population;
            DominantSpecies = species;
        }

        private HabitablePlanet(HabitablePlanet source) : base(source)
        {
            Population = source.Population;
            DominantSpecies = source.DominantSpecies;
        }

        public override SpaceObject Clone() => new HabitablePlanet(this);
    }
}