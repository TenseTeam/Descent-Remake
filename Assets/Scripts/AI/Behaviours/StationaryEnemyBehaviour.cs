namespace ProjectDescent.AI.Behaviours
{
    using Extension.StateMachine;
    using Extension.TransformExtensions;
    using ProjectDescent.AI.States;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using UnityEngine;

    public class StationaryEnemyBehaviour : StateMachine
    {
        [field: SerializeField, Header("Weapon")]
        public WeaponBase Weapon { get; set; }

        [field: SerializeField, Header("Target")]
        public Transform Target { get; set; }


        [field: SerializeField, Header("Ranges")]
        public float AttackRange { get; private set; } = 10f;


        [field: SerializeField, Header("Speeds")]
        public float RotationSpeed { get; private set; } = 2f;

        protected override void InitStates()
        {
            base.InitStates();

            States.Add("Idle", null);
            States.Add("Shoot", new ShootState("Shoot", transform, Target, Weapon, RotationSpeed));
        }

        protected override void Update()
        {
            base.Update();
            float distance = Vector3.Distance(transform.position, Target.position);

            if (distance < AttackRange && transform.IsPathClear(Target, AttackRange))
            {
                ChangeState("Shoot");
            }
            else
            {
                ChangeState("Idle");
            }
        }
    }
}