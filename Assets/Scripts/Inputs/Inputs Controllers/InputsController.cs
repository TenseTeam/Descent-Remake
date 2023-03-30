namespace ProjectDescent.InputControllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class InputsController : MonoBehaviour
    {
        private void OnEnable() 
        {
            Enable();
        }
        private void OnDisable()
        {
            Disable();
        }

        public abstract void Enable();
        public abstract void Disable();
    }
}
