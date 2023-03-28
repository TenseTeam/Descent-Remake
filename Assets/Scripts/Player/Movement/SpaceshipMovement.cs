namespace ProjectDescent.Player.Movement
{
    using Extension.Mathematics;
    using ProjectDescent.InputControllers;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody), typeof(SpaceshipInputsController))]
    public class SpaceshipMovement : MonoBehaviour
    {
        [field: Header("Movement"), SerializeField]
        public float MaxSpeed { get; set; } = 5f;

        [field: SerializeField]
        public Vector3 MovementAcceleration { get; set; } = Vector3.one * 10f;

        [field: Header("Principal Rotation Axes"), SerializeField]
        public float RollSpeed { get; private set; } = .2f;

        [field: SerializeField]
        public float YawSpeed { get; private set; } = .2f;

        [field: SerializeField]
        public float PitchSpeed { get; private set; } = .2f;

        [field: Header("Tilt"), SerializeField, Range(0, 360)]
        public ushort TiltAngleRotation { get; private set; } = 25;

        [field: SerializeField]
        public float TiltSpeed { get; private set; } = 1f;

        [field: Header("Resetting"), SerializeField, Range(0, 360)]
        public ushort ResettingRotationAngle { get; private set; } = 90;

        [field: SerializeField]
        public float ResettingSpeed { get; private set; } = 1f;

        [Header("Oscillation")]
        [SerializeField]
        private float _frequency = 2f;

        [SerializeField]
        private float _amplitude = .5f;

        [SerializeField]
        private float _oscillationForceMagnitude = 2f;

        private Rigidbody _rb;
        private SpaceshipInputsController _inputs;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _inputs = GetComponent<SpaceshipInputsController>();
        }

        private void FixedUpdate()
        {
            RotationOnPrincipalAxes();
            Movement();
            Oscillation();
        }

        private void LateUpdate()
        {
            if (_inputs.IsMouseYawing)
                TiltOnRotation();

            if (!_inputs.IsMouseRotating)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, Math.GetClosestMultipleAngle(transform.localEulerAngles.z, ResettingRotationAngle)), ResettingSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Moves the rigidbody by the SpaceshipInputsController inputs.
        /// </summary>
        private void Movement()
        {
            Vector3 movementAxis = _inputs.MovementAxis;

            Vector3 move = new Vector3(movementAxis.x * MovementAcceleration.x, movementAxis.y * MovementAcceleration.y, movementAxis.z * MovementAcceleration.z);
            move = transform.right * move.x + Vector3.up * move.y + transform.forward * move.z;

            if (_rb.velocity.magnitude <= MaxSpeed)
                _rb.AddForce(move, ForceMode.Acceleration);
        }

        /// <summary>
        /// Rotates the rigidbody by the SpaceshipInputsController inputs.
        /// </summary>
        private void RotationOnPrincipalAxes()
        {
            float yaw = _inputs.MouseYaw;
            float pitch = _inputs.MousePitch;
            float roll = _inputs.Roll;

            _rb.AddRelativeTorque(Vector3.up * yaw * YawSpeed);
            _rb.AddRelativeTorque(Vector3.right * pitch * PitchSpeed);
            _rb.AddRelativeTorque(Vector3.forward * roll * RollSpeed);
        }

        /// <summary>
        /// Applies an oscillation to the rigidbody.
        /// </summary>
        private void Oscillation()
        {
            float yPos = Mathf.Sin(Time.time * _frequency) * _amplitude;

            Vector3 force = new Vector3(0f, yPos, 0f) * _oscillationForceMagnitude;

            _rb.AddForce(force, ForceMode.Force);
        }

        /// <summary>
        /// Lerp Rotates the transform by the TiltAngleRotation.
        /// </summary>
        private void TiltOnRotation()
        {
            float tiltAngle = Mathf.Lerp(0f, TiltAngleRotation, Mathf.Abs(_inputs.MouseYaw));

            Vector3 eulerAngles = transform.localEulerAngles;
            eulerAngles.z = Mathf.LerpAngle(eulerAngles.z, -tiltAngle * Mathf.Sign(_inputs.MouseYaw), TiltSpeed * Time.deltaTime);
            transform.localEulerAngles = eulerAngles;
        }
    }
}