namespace ProjectDescent.InputControllers
{
    using UnityEngine;


    /// <summary>
    /// Class for managing the inputs of the spaceship
    /// </summary>
    public class SpaceshipInputsController : InputsController
    {
        [field: SerializeField, Range(0f, 1f)]
        public float Deadzone { get; private set; } = 0.2f;

        [field: SerializeField]
        public Inputs Inputs { get; private set; }

        private void Awake()
        {
            Inputs = new Inputs();
            Inputs.Enable();
        }

        public override void Enable()
        {
            Inputs.Enable();
        }

        public override void Disable()
        {
            Inputs.Disable();
        }

        public Vector3 MovementAxis => Inputs.Aircraft.Movement.ReadValue<Vector3>();
        public float Pitch => Inputs.Aircraft.Pitch.ReadValue<float>();
        public float Yaw => Inputs.Aircraft.Yaw.ReadValue<float>();
        public float Roll => Inputs.Aircraft.Roll.ReadValue<float>();
        public float MousePitch => ApplyDeadzone((Pitch - Screen.height * .5f) / (Screen.height * .5f), Deadzone) * -1f;
        public float MouseYaw => ApplyDeadzone((Yaw - Screen.width * .5f) / (Screen.width * .5f), Deadzone);


        public bool IsMouseYawing => Mathf.Abs(MouseYaw) > 0f;
        public bool IsMousePitching => Mathf.Abs(MousePitch) > 0f;

        public bool IsRolling => Inputs.Aircraft.Roll.IsPressed();
        public bool IsYawing => Inputs.Aircraft.Yaw.IsPressed(); 
        public bool IsPitching => Inputs.Aircraft.Pitch.IsPressed();

        public bool IsMouseRotating => IsMousePitching || IsMouseYawing || IsRolling;
        public bool IsRotating => IsPitching || IsYawing || IsRolling;

        /// <summary>
        /// Applies a deadzone to a given value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="deadzone">Deadzone threshold.</param>
        /// <returns>Value clamped by the given deadzone.</returns>
        private float ApplyDeadzone(float value, float deadzone)
        {
            if (Mathf.Abs(value) > deadzone)
            {
                return value;
            }

            return 0f;
        }

    }
}