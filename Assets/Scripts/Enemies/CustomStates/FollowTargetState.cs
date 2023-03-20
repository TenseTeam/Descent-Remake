namespace ProjectDescent.AI.States
{
    using UnityEngine;
    using AStarAI.Data.StateMachine;
    using AStarAI.Agents;


    public class FollowTargetState : State
    {
        public AgentUnit Agent { get; protected set; }

        public FollowTargetState(string name, AgentUnit agent) : base(name)
        {
            Agent = agent;
        }

        public override void Enter()
        {
            Agent.StartCalculatingPathAndMoveToTarget();
        }

        public override void Exit()
        {
            Agent.StopCalculatingPath();
        }

        public override void Process()
        {
        }
    }
}
