
namespace ProjectDescent.EntitySystem.Interfaces
{
    interface IEntityVulnerable : IVulnerable
    {
        float MaxHitPoints { get; set; }

        void HealHitPoints(float healPoints);
    }
}