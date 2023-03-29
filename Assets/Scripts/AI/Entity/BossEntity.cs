namespace ProjectDescent.AI.Behaviours
{
    using ProjectDescent.EntitySystem;
    using UnityEngine;

    public class BossEntity : EnemyEntity
    {
        [field: SerializeField]
        public Animator Animator { get; private set; }

        public override void Death()
        {
            Animator.SetTrigger("open");
            base.Death();
        }
    }
}