namespace ProjectDescent.AI.Behaviours
{
    using AStarAI.Agents;
    using AStarAI.Data.StateMachine;
    using ProjectDescent.AI.States;
    using UnityEngine;

    [RequireComponent(typeof(AgentUnit))]
    public class OrangeEnemySpaceshipBehaviour : FiniteStateMachine
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private float _detectionRange = 10f;

        private AgentUnit _agent;

        protected override void InitStates()
        {
            base.InitStates();
            States.Add("Idle", new IdleState("Idle"));
            States.Add("Follow", new FollowTargetState("Follow Target", _agent));
            InitialState = States["Idle"];
        }

        protected override void Start()
        {
            _agent = GetComponent<AgentUnit>();
            _agent.Target = _target;
            base.Start();
        }

        protected override void Update()
        {
            Debug.Log(Vector3.Distance(transform.position, _target.position));

            if (Vector3.Distance(transform.position, _target.position) < _detectionRange)
            {
                ChangeState(States["Follow"]);
            }
            else
            {
                ChangeState(States["Idle"]);
            }

            base.Update();
        }
    }
}