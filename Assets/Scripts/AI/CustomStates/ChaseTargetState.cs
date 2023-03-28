namespace ProjectDescent.AI.States
{
    using UnityEngine;
    using UnityEngine.AI;
    using Extension.StateMachine;
    using Extension.TransformExtensions;

    public class ChaseTargetState : State
    {
        private Transform _self;
        private Transform _target;

        private float _rotationSpeed;
        private float _speed;

        public ChaseTargetState(string name, Transform self, Transform target, float rotationSpeed, float speed) : base(name)
        {
            _self = self;
            _target = target;
            _rotationSpeed = rotationSpeed;
            _speed = speed;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
            _self.LookAtLerp(_target, _rotationSpeed * Time.deltaTime);
            _self.position = Vector3.MoveTowards(_self.position, _target.position, _speed * Time.deltaTime);
        }
    }
}
