namespace AStarAI.Data.StateMachine
{
    using System.Collections.Generic;
    using UnityEngine;

    public class FiniteStateMachine : MonoBehaviour
    {
        public State CurrentState { get; private set; }
        protected State InitialState { get; set; }
        protected Dictionary<string, State> States { get; set; }

        protected virtual void InitStates()
        {
            States = new Dictionary<string, State>();
        }

        protected virtual void Start()
        {
            InitStates();
            CurrentState = InitialState;
            if (CurrentState != null)
                CurrentState.Enter();
        }

        protected virtual void Update()
        {
            if (CurrentState != null)
                CurrentState.Process();
        }

        protected void ChangeState(State state)
        {
            if (state != CurrentState)
            {
                CurrentState.Exit();
                CurrentState = state;
                CurrentState.Enter();
            }
        }
    }
}