namespace HW5
{
    public class CrewedStarship : Starship
    {
        public int CurrentCrew { get; set; }
        public string Captain { get; set; }

        public CrewedStarship(string name, double fuel, int currentCrew, string captain)
            : base(name, 1200, fuel, 100, 150_000)
        {
            CurrentCrew = currentCrew;
            Captain = captain;
        }

        private CrewedStarship(CrewedStarship source) : base(source)
        {
            CurrentCrew = source.CurrentCrew;
            Captain = source.Captain;
        }

        public override SpaceObject Clone() => new CrewedStarship(this);
    }
}