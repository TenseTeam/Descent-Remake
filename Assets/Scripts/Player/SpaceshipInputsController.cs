using System.Collections;
using UnityEngine;

public class SpaceshipInputsController : MonoBehaviour
{
    public enum AxisType : sbyte
    {
        Nullified = 0,
        Normal = 1,
        Inverted = -1
    }

    [SerializeField]
    private float _rotatationLerpVelocity;

    private Vector3 rotation;

    [Header("Axes")]
    public AxisType pitchAxis = AxisType.Normal;
    public AxisType yawAxis = AxisType.Normal;
    public AxisType rollAxis = AxisType.Normal;

    public Inputs Inputs { get => _inputs; set => _inputs = value; }

    private Inputs _inputs;

    private void Awake()
    {
        _inputs = new Inputs();
        _inputs.Enable();
        StartCoroutine(CalculateRotation());
    }

    public Vector3 MovementAxis => _inputs.Aircraft.Movement.ReadValue<Vector3>();

    public float Yaw => rotation.y;

    public float Roll => rotation.z;

    public float Pitch => rotation.x;

    public bool IsRolling => Roll != 0;
    public bool IsPitching => Pitch != 0;
    public bool IsYawing => Yaw != 0;
    public bool IsRotating => IsRolling || IsPitching || IsYawing;

    private IEnumerator CalculateRotation()
    {
        while (true)
        {
            Vector3 rot = new Vector3
                (
                _inputs.Aircraft.Pitch.ReadValue<float>() * (float)pitchAxis,
                _inputs.Aircraft.Yaw.ReadValue<float>() * (float)yawAxis,
                _inputs.Aircraft.Roll.ReadValue<float>() * (float)rollAxis
                );

            rotation = Vector3.Lerp(rotation, rot, _rotatationLerpVelocity * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}