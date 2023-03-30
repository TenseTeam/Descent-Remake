namespace ProjectDescent.InputControllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PauseMenuInputsController : InputsController
    {
        [field: SerializeField]
        public InputAction OpenPauseMenuAction { get; private set; }

        public override void Enable()
        {
            OpenPauseMenuAction.Enable();
        }

        public override void Disable()
        {
            OpenPauseMenuAction.Disable();
        }

    }

}