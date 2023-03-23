namespace ProjectDescent.AI.States
{
    using ProjectDescent.AI.Interfaces;

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