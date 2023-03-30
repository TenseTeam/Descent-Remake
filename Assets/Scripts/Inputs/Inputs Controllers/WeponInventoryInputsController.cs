namespace ProjectDescent.InputControllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class WeponInventoryInputsController : InputsController
    {
        [field: SerializeField]
        public InputAction ShootAction { get; private set; }

        [field: SerializeField]
        public InputAction SwitchAction { get; private set; }

        public override void Enable()
        {
            ShootAction.Enable();
            SwitchAction.Enable();
        }

        public override void Disable()
        {
            ShootAction.Disable();
            SwitchAction.Disable();
        }

        public int SwitchWeapon => (int)SwitchAction.ReadValue<float>();
        public bool IsShooting => ShootAction.IsPressed();
    }
}
