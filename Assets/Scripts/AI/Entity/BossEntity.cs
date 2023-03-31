namespace ProjectDescent.AI.Behaviours
{
    using ProjectDescent.EntitySystem;
    using UnityEngine;
    using ProjectDescent.UI.Countdown;

    public class BossEntity : EnemyEntity
    {
        [field: SerializeField, Header("Animator To Trigger")]
        public Animator Animator { get; private set; }

        [field: SerializeField]
        public string AnimatorTriggerParameter { get; set; }


        [field: SerializeField, Header("Countdown")]
        public CountdownTimer Countdown { get; private set; }

        [field: SerializeField]
        public int CountdownTime { get; private set; }

        public override void Death()
        {
            Animator.SetTrigger(AnimatorTriggerParameter);
            Countdown.StartTimer(CountdownTime);
            base.Death();
        }
    }
}