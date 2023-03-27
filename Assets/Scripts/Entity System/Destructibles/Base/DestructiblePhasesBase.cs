namespace ProjectDescent.EntitySystem.Destructibles
{
    using ProjectDescent.EntitySystem.Interfaces;
    using System.Collections.Generic;
    using UnityEngine;

    public class DestructiblePhasesBase : MonoBehaviour, IVulnerable
    {
        [field: SerializeField]
        public List<int> ChangePhaseAt { get; set; }

        [field: SerializeField]
        public float HitPoints { get; set; }

        private Queue<int> _queuePhases;

        private void Start()
        {
            Setup();
        }

        protected virtual void Setup()
        {
            ChangePhaseAt.Sort();
            ChangePhaseAt.Reverse();
            _queuePhases = new Queue<int>(ChangePhaseAt);
        }

        public void TakeDamage(float hitDamage = 1)
        {
            HitPoints -= hitDamage;

            if (HitPoints < 0)
                Death();

            if(_queuePhases.TryPeek(out int peek)
                && HitPoints < peek)
            {
                NextPhase();
            }
        }

        public virtual void NextPhase()
        {
            _queuePhases.Dequeue();
            Debug.Log("Changed Phase of destruction");
        }

        public virtual void Death()
        {
            HitPoints = 0;
            Destroy(gameObject);
            Debug.Log("Completely Destroyed");
        }
    }
}