namespace ProjectDescent.AI.Interfaces
{
    internal interface IEventState
    {
        public void Enter();

        public void Exit();

        public void Process();
    }
}