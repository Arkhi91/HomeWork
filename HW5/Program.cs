using HW5;

class Program
{
    static void Main()
    {
        Console.WriteLine("Паттерн Прототип — Космическая тематика\n");

        #region Оригиналы
        var sun = new Star("Солнце", 1.989e9, 696_000, 5778, "G2V");
        var earth = new HabitablePlanet("Земля", 5.972e6, 6_371, 81000);
        var falcon = new CrewedStarship("Endeavour", 600, 7, "Илон Маск");
        var voyager = new Probe("Voyager 1", 825, 0, "Исследование внешней Солнечной системы");

        Console.WriteLine("Исходные объекты:");
        Print(sun);
        Print(earth);
        Print(falcon);
        Print(voyager);
        #endregion

        #region Клоны
        var sun2 = (Star)sun.Clone();
        var earth2 = (HabitablePlanet)earth.Clone();
        var falcon2 = (CrewedStarship)falcon.Clone();

        sun2.Name = "Солнце-2";
        earth2.Population = 10000;
        falcon2.Captain = "Новый молодой капитан";

        Console.WriteLine("\nКлоны через IMyCloneable<T>:");
        Print(sun2);
        Print(earth2);
        Print(falcon2);
        #endregion

        Console.WriteLine("\nПосле изменения оригиналов (клоны не изменились):");
        earth.Population = 95000;
        falcon.Captain = "Грок 4";

        Console.WriteLine($"Оригинал Земля: население = {earth.Population:N0}");
        Console.WriteLine($"Клон Земли: население = {earth2.Population:N0}");
        Console.WriteLine($"Оригинал корабль: капитан = {falcon.Captain}");
        Console.WriteLine($"Клон корабль: капитан = {falcon2.Captain}");

        var voyagerClone = (Probe)((ICloneable)voyager).Clone();
        Console.WriteLine($"\nКлон Voyager через ICloneable: {voyagerClone.Name}, миссия: {voyagerClone.Mission}");
    }
    static void Print(SpaceObject obj) => Console.WriteLine($"{obj.GetType().Name,-15} | {obj.Name,-8} | масса {obj.Mass:E2} т");   
}