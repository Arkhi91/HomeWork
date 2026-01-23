using HW6.Domain;

namespace HW6.Abstractions
{
    public interface ISettingsProvider
    {
        GameSettings GetSettings();
    }
}