namespace ProjectDescent.EntitySystem
{
    using ProjectDescent.EntitySystem.Interfaces;
    using UnityEngine;

    public class EntityBase : MonoBehaviour, IEntityVulnerable
    {
        [Header("Stats")]
        public float maxHitPoints;
        public float startingHitPoints;

        public float HitPoints { get; set; }

        private void Start()
        {
            SetupHP();
        }

        protected virtual void SetupHP()
        {
            HitPoints = startingHitPoints;

            if (HitPoints > startingHitPoints)
            {
                startingHitPoints = maxHitPoints;
                HitPoints = startingHitPoints;
            }
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            HitPoints -= Mathf.Abs(hitDamage);

            if (HitPoints <= 0.1f)
            {
                HitPoints = 0f;
                Death();
            }
        }

        public virtual void HealHitPoints(float healPoints)
        {
            HitPoints += Mathf.Abs(healPoints);

            if (HitPoints > maxHitPoints)
                HitPoints = maxHitPoints;
        }

        public virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}