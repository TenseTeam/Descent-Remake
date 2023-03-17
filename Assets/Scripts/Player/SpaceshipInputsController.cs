using System.Collections;
using System.Collections.Generic;
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

    internal Vector3 MovementAxis => _inputs.Aircraft.Movement.ReadValue<Vector3>();

    internal float Yaw => _inputs.Aircraft.Yaw.ReadValue<float>() * (float)yawAxis;

    internal float Roll => _inputs.Aircraft.Roll.ReadValue<float>() * (float)rollAxis;

    internal float Pitch => _inputs.Aircraft.Pitch.ReadValue<float>() * (float)pitchAxis;

    internal bool IsRolling => Roll != 0;
    internal bool IsPitching => Pitch != 0;
    internal bool IsYawing => Yaw != 0;

    internal bool IsRotating => IsRolling || IsPitching || IsYawing;
}
