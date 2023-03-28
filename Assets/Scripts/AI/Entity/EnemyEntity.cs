namespace ProjectDescent.AI.Behaviours
{
    using ProjectDescent.EntitySystem;
    using UnityEngine;

    public class EnemyEntity : EntityBase
    {
        [field: SerializeField, Header("VFXOnDeath")]
        public GameObject VFXExplosion { get; private set; }

        public override void Death()
        {
            Instantiate(VFXExplosion, transform.position, transform.rotation);
            base.Death();
        }
    }
}