namespace ProjectDescent.AI.StateMachine
{
    using System.Collections.Generic;
    using ProjectDescent.AI.States;
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

        protected void ChangeState(string stateKey)
        {
            if (States[stateKey] != CurrentState)
            {
                CurrentState.Exit();
                CurrentState = States[stateKey];
                CurrentState.Enter();
            }
        }
    }
}