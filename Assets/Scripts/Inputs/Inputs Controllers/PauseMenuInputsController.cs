namespace ProjectDescent.InputControllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PauseMenuInputsController : MonoBehaviour
    {
        [field: SerializeField]
        public InputAction OpenPauseMenuAction { get; private set; }

        private void OnEnable()
        {
            OpenPauseMenuAction.Enable();
            OpenPauseMenuAction.Enable();
        }

        private void OnDisable()
        {
            OpenPauseMenuAction.Disable();
            OpenPauseMenuAction.Disable();
        }
    }

}