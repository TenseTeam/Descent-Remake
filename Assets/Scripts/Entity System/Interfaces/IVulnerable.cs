
namespace ProjectDescent.EntitySystem.Interfaces
{
    interface IVulnerable
    {
        float HitPoints { get; set; }

        void TakeDamage(float hitDamage = 1f);

        void Death();
    }
}