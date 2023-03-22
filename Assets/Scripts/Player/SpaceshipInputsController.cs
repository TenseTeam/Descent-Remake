using UnityEngine;

public class SpaceshipInputsController : MonoBehaviour
{
    public enum AxisType : sbyte
    {
        Nullified = 0,
        Normal = 1,
        Inverted = -1
    }    

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
    }

    public Vector3 MovementAxis => _inputs.Aircraft.Movement.ReadValue<Vector3>();

    public float Yaw => _inputs.Aircraft.Yaw.ReadValue<float>();

    public float Roll => _inputs.Aircraft.Roll.ReadValue<float>();

    public float Pitch => _inputs.Aircraft.Pitch.ReadValue<float>();

    public bool IsRolling => Roll != 0;
    public bool IsPitching => Pitch != 0;
    public bool IsYawing => Yaw != 0;
    public bool IsRotating => IsRolling || IsPitching || IsYawing;
}