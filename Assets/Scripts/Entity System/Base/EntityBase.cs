namespace ProjectDescent.EntitySystem
{
    using ProjectDescent.EntitySystem.Interfaces;
    using UnityEngine;

    public class EntityBase : MonoBehaviour, IEntityVulnerable
    {
        [field: SerializeField]
        public float MaxHitPoints { get; set; }

        public float HitPoints { get; set; }

        private void Start()
        {
            SetupHP();
        }

        protected virtual void SetupHP()
        {
            HitPoints = MaxHitPoints;
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            HitPoints -= hitDamage;

            if (HitPoints < 0f)
            {
                HitPoints = 0f;
                Death();
            }
        }

        public void HealHitPoints(float healPoints)
        {
            HitPoints += healPoints;

            if (HitPoints > MaxHitPoints)
                HitPoints = MaxHitPoints;
        }

        public virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}