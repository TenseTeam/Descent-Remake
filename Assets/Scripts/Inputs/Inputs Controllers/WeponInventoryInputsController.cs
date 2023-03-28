namespace ProjectDescent.InputControllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class WeponInventoryInputsController : MonoBehaviour
    {
        [field: SerializeField]
        public InputAction ShootAction { get; private set; }

        [field: SerializeField]
        public InputAction SwitchAction { get; private set; }

        private void OnEnable()
        {
            ShootAction.Enable();
            SwitchAction.Enable();
        }

        private void OnDisable()
        {
            ShootAction.Disable();
            SwitchAction.Disable();
        }

        public int SwitchWeapon => (int)SwitchAction.ReadValue<float>();
        public bool IsShooting => ShootAction.IsPressed();
    }
}
