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

        private NavMeshAgent _agent;

        protected override void InitStates()
        {
            base.InitStates();

            _agent = GetComponent<NavMeshAgent>();

            States.Add("Idle", null);
            States.Add("Chase", new ChaseTargetState("Chase", _agent, _target));
        }

        protected override void Start()
        {
            base.Start();
            _agent.stoppingDistance = _attackRange;
        }

        protected override void Update()
        {
            base.Update();
#if DEBUG
            Debug.Log(Vector3.Distance(transform.position, _target.position));
#endif
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance < _detectionRange)
            {
                ChangeState("Chase");

                if (distance < _attackRange)
                    Debug.Log("Attack"); // To change with shooting
            }
            else
            {
                ChangeState("Idle");
            }
        }
    }
}