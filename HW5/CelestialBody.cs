using HW5;

public abstract class CelestialBody : SpaceObject
{
    public double Radius { get; set; } //км
    public double SurfaceTemperature { get; set; } //цельсии или Кельвины, пока без разницы

    protected CelestialBody(string name, double mass, double radius, double temp,
                            double x = 0, double y = 0, double z = 0)
        : base(name, mass, x, y, z)
    {
        Radius = radius;
        SurfaceTemperature = temp;
    }

    protected CelestialBody(CelestialBody source) : base(source)
    {
        Radius = source.Radius;
        SurfaceTemperature = source.SurfaceTemperature;
    }
}