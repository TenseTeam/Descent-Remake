namespace ProjectDescent.EntitySystem
{
    using ProjectDescent.EntitySystem.Interfaces;
    using UnityEngine;

    public class EntityBase : MonoBehaviour, IEntityVulnerable
    {
        [Header("Stats")]
        public float maxHitPoints;
        public float startingHitPoints;

        protected float hitPoints;
         
        private void Start()
        {
            SetupHP();
        }

        protected virtual void SetupHP()
        {
            hitPoints = startingHitPoints;

            if (hitPoints > startingHitPoints)
            {
                startingHitPoints = maxHitPoints;
                hitPoints = startingHitPoints;
            }
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            hitPoints -= Mathf.Abs(hitDamage);

            if (hitPoints <= 0.1f)
            {
                hitPoints = 0f;
                Death();
            }
        }

        public virtual void HealHitPoints(float healPoints)
        {
            hitPoints += Mathf.Abs(healPoints);

            if (hitPoints > maxHitPoints)
                hitPoints = maxHitPoints;
        }

        public virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}