
namespace ProjectDescent.Player.Camera
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class RearViewOnInput : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject FrontInterface { get; private set; }

        [field: SerializeField]
        public GameObject BackInterface { get; private set; }

        [field: SerializeField]
        public Camera Camera { get; private set; }

        [field: SerializeField]
        public InputAction RearViewAction { get; private set; }

        private void Start()
        {
            RearViewAction.Enable();
            RearViewAction.performed += RearViewOn;
            RearViewAction.canceled += RearViewOff;
        }

        private void RearViewOn(InputAction.CallbackContext obj)
        {
            Camera.transform.Rotate(Vector3.up, 180);
            FrontInterface.SetActive(false);
            BackInterface.SetActive(true);
        }

        private void RearViewOff(InputAction.CallbackContext obj)
        {
            Camera.transform.Rotate(Vector3.up, 180);
            FrontInterface.SetActive(true);
            BackInterface.SetActive(false);
        }
    }
}
