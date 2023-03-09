using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(SpaceshipInputsController))]
public class SpaceshipMovement : MonoBehaviour
{
    [Header("Movement")]
    public float maxSpeed = 5f;
    [SerializeField]
    private Vector3 _movementAcceleration;

    [Header("Principal Rotation Axes")]
    [SerializeField]
    private float _rollSpeed = 2f;
    [SerializeField]
    private float _yawSpeed = 2f;
    [SerializeField]
    private float _pitchSpeed = 2f;
    [SerializeField]
    private Space _rollRelativeRotation;
    [SerializeField]
    private Space _yawRelativeRotation;
    [SerializeField]
    private Space _pitchRelativeRotation;

    [SerializeField]
    private float _zRotationSnap = 90f;
    [SerializeField]
    private float _zRotationOnSwing = 45f;

    [Header("Settling")]
    [SerializeField]
    private float _resettingSpeed = 2f;

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
        Movement();
        RotationOnPrincipalAxes();
        Oscillation();
    }

    private void LateUpdate()
    {
        if (_inputs.IsYawing)
            LerpRotate(Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, _zRotationOnSwing * _inputs.Yaw * -1f));

        if(!_inputs.IsRolling && !_inputs.IsYawing)
            LerpRotate(Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, GetClosestMultipleAngleOf(transform.localEulerAngles.z, _zRotationSnap)));
    }

    private void Movement()
    {
        Vector3 movementAxis = _inputs.MovementAxis;

        Vector3 move = new Vector3(movementAxis.x * _movementAcceleration.x, movementAxis.y * _movementAcceleration.y, movementAxis.z * _movementAcceleration.z);
        move = transform.right * move.x + Vector3.up * move.y + transform.forward * move.z;

        if (_rb.velocity.magnitude <= maxSpeed)
            _rb.AddForce(move, ForceMode.Acceleration);
    }

    private void RotationOnPrincipalAxes()
    {
        Pitch(_pitchRelativeRotation);
        Roll(_rollRelativeRotation);
        Yaw(_yawRelativeRotation);
    }

    private void Pitch(Space space)
    {
        float pitchX = _inputs.Pitch * _pitchSpeed;
        transform.Rotate(Vector3.right, pitchX, space);
    }

    private void Roll(Space space)
    {
        float rollZ = _inputs.Roll * _rollSpeed;
        transform.Rotate(Vector3.forward, rollZ, space);
    }

    private void Yaw(Space space)
    {
        float yawY = _inputs.Yaw * _yawSpeed;
        transform.Rotate(Vector3.up, yawY, space);
    }

    private void Oscillation()
    {
        float yPos = Mathf.Sin(Time.time * _frequency) * _amplitude;

        Vector3 force = new Vector3(0f, yPos, 0f) * _oscillationForceMagnitude;

        _rb.AddForce(force, ForceMode.Force);
    }

    private void LerpRotate(Quaternion endRotation)
    {
        transform.localRotation = 
            Quaternion.Lerp
            (
            transform.localRotation,
            endRotation,
            _resettingSpeed * Time.deltaTime
            );
    }

    private float GetClosestMultipleAngleOf(float angle, float multiple)
    {
        return Mathf.Round(angle / multiple) * multiple;
    }
}