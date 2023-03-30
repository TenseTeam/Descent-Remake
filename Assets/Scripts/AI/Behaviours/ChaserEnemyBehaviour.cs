namespace ProjectDescent.AI.Behaviours
{
    using Extension.StateMachine;
    using Extension.TransformExtensions;
    using ProjectDescent.AI.States;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using UnityEngine;
    using UnityEngine.AI;

    public class ChaserEnemyBehaviour : StateMachine
    {
        [field: SerializeField, Header("Weapon")]
        public WeaponBase Weapon { get; set; }

        [field: SerializeField, Header("Target")]
        public Transform Target { get; set; }


        [field: SerializeField, Header("Ranges")]
        public float DetectionRange { get; private set; } = 10f;
        [field: SerializeField]
        public float StoppingDistance { get; set; }

        public LayerMask layerMaskPathRaycast;


        [field: SerializeField, Header("Speeds")]
        public float MovementSpeed { get; set; } = 2f;
        [field: SerializeField]
        public float RotationSpeed { get; private set; } = 2f;


        protected override void InitStates()
        {
            base.InitStates();

            States.Add("Idle", null);
            States.Add("Chase", new ChaseTargetState("Chase", transform, Target, RotationSpeed, MovementSpeed, Weapon, StoppingDistance));
        }

        protected override void Update()
        {
            base.Update();
            float distance = Vector3.Distance(transform.position, Target.position);

            if (distance < DetectionRange && transform.IsPathClear(Target, layerMaskPathRaycast))
            {
                ChangeState("Chase");
            }
            else
            {
                ChangeState("Idle");
            }
        }

    }
}