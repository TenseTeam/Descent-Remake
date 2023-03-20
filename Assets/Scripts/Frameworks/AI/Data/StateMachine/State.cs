namespace AStarAI.Data.StateMachine
{
    using AStarAI.Data.Interfaces;

    public abstract class State : IEventState
    {
        public string Name { get; private set; }

        protected State(string name)
        {
            Name = name;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Process();
    }
}