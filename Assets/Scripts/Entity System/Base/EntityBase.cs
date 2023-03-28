namespace ProjectDescent.EntitySystem
{
    using ProjectDescent.EntitySystem.Interfaces;
    using UnityEngine;

    public class EntityBase : MonoBehaviour, IEntityVulnerable
    {
        [field: SerializeField, Header("Stats")]
        public float maxHitPoints;

        public float HitPoints { get; set; }

        private void Start()
        {
            SetupHP();
        }

        protected virtual void SetupHP()
        {
            HitPoints = maxHitPoints;
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            HitPoints -= Mathf.Abs(hitDamage);

            if (HitPoints < 0f)
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