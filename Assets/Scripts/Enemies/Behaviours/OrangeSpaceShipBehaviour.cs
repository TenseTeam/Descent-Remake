namespace ProjectDescent.AI.Behaviours
{
    using UnityEngine;
    using UnityEngine.AI;
    using ProjectDescent.AI.StateMachine;
    using ProjectDescent.AI.States;

    [RequireComponent(typeof(NavMeshAgent))]
    public class OrangeSpaceShipBehaviour : FiniteStateMachine
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private float _detectionRange = 10f;

        private NavMeshAgent _agent;

        protected override void InitStates()
        {
            base.InitStates();
            States.Add("Idle", new IdleState("Idle"));
            States.Add("Chase", new ChaseTargetState("Chase", _agent, _target));
            InitialState = States["Idle"];
        }

        protected override void Update()
        {
            Debug.Log(Vector3.Distance(transform.position, _target.position));

            if (Vector3.Distance(transform.position, _target.position) < _detectionRange)
            {
                ChangeState("Follow");
            }
            else
            {
                ChangeState("Idle");
            }

            base.Update();
        }
    }
}