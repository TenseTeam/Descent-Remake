namespace ProjectDescent.AI.Behaviours
{
    using ProjectDescent.EntitySystem;
    using UnityEngine;

    public class BossEntity : EnemyEntity
    {
        [field: SerializeField]
        public Animator Animator { get; private set; }

        [field: SerializeField]
        public string AnimatorTriggerParameter { get; set; }

        [field: SerializeField]
        public CountdownTimer Countdown { get; private set; }

        public override void Death()
        {
            Animator.SetTrigger(AnimatorTriggerParameter);
            Countdown.StartTimer();
            base.Death();
        }
    }
}