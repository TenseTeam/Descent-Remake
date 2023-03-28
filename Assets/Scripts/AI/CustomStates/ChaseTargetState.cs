namespace ProjectDescent.AI.States
{
    using UnityEngine;
    using UnityEngine.AI;
    using Extension.StateMachine;
    using Extension.TransformExtensions;
    using ProjectDescent.ItemSystem.Items.Weapons;

    public class ChaseTargetState : State
    {
        public WeaponBase Weapon { get; set; }
        public float StoppingDistance = 2f;

        private Transform _self;
        private Transform _target;

        private float _rotationSpeed;
        private float _speed;

        public ChaseTargetState(string name, Transform self, Transform target, float rotationSpeed, float speed, WeaponBase weaponUsed, float stoppingDistance) : base(name)
        {
            _self = self;
            _target = target;
            _rotationSpeed = rotationSpeed;
            _speed = speed;
            Weapon = weaponUsed;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
            Weapon.PullTrigger();
            _self.LookAtLerp(_target, _rotationSpeed * Time.deltaTime);
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if(Vector3.Distance(_self.position, _target.position) > StoppingDistance)
                _self.position = Vector3.MoveTowards(_self.position, _target.position, _speed * Time.deltaTime);
        }
    }
}
