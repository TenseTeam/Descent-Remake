namespace ProjectDescent.AI.Behaviours
{
    using ProjectDescent.AI.StateMachine;
    using ProjectDescent.AI.States;
    using UnityEngine;
    using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
    public class ChaserSpaceShipBehaviour : FiniteStateMachine
    {
        [Header("Target")]
        [SerializeField]
        private Transform _target;

        [Header("Ranges")]
        [SerializeField]
        private float _detectionRange = 10f;
        [SerializeField]
        private float _attackRange = 10f;
        [SerializeField]
        private float _rotationSpeed = 2f;

        [Header("Shooting")]
        [SerializeField]
        private float _fireRate = 0.5f;
        [SerializeField]
        private GameObject _bullet;
        [SerializeField]
        private Transform[] _spawnPoints;

        private NavMeshAgent _agent;

        protected override void InitStates()
        {
            base.InitStates();

            _agent = GetComponent<NavMeshAgent>();

            States.Add("Idle", null);
            States.Add("Chase", new ChaseTargetState("Chase", _agent, _target));
            States.Add("Shoot", new ShootState("Shoot", transform, _target, _spawnPoints, _fireRate, _rotationSpeed, _bullet));
        }

        protected override void Start()
        {
            base.Start();
            _agent.stoppingDistance = _attackRange;
        }

        protected override void Update()
        {
            base.Update();
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance < _detectionRange)
            {
                ChangeState("Chase");

                if (distance < _attackRange)
                    ChangeState("Shoot");
            }
            else
            {
                ChangeState("Idle");
            }
        }
    }
}