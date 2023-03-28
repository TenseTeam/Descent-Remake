
namespace ProjectDescent.EntitySystem.Interfaces
{
    interface IEntityVulnerable : IVulnerable
    {
        void HealHitPoints(float healPoints);
    }
}