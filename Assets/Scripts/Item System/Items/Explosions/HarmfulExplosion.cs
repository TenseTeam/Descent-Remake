
namespace ProjectDescent.ItemSystem.Items.Explosions
{
    using UnityEngine;
    using ProjectDescent.Utilities;
    using ProjectDescent.EntitySystem.Interfaces;

    [RequireComponent(typeof(Collider))]
    public class HarmfulExplosion : DestroyAfterSeconds
    {
        [field: SerializeField, Header("Stats")]
        public float Damage { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IVulnerable ent))
            {
                ent.TakeDamage(Damage);
            }
        }
    }
}
