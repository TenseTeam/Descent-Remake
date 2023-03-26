namespace ProjectDescent.AI.States
{
    using UnityEngine;
    using UnityEngine.AI;
    using Extension.StateMachine;

    public class ChaseTargetState : State
    {
        public NavMeshAgent Agent { get; private set; }
        public Transform Target { get; set; }

        public ChaseTargetState(string name, NavMeshAgent agent, Transform target) : base(name)
        {
            Agent = agent;
            Target = target;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            Agent.SetDestination(Agent.transform.position);
        }

        public override void Process()
        {
            Agent.SetDestination(Target.position);
        }
    }
}
