
namespace ProjectDescent.EntitySystem.Interfaces
{
    interface IVulnerable
    {
        void TakeDamage(float hitDamage = 1f);

        void Death();
    }
}