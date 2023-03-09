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
    public AxisType invertPitchAxis = AxisType.Normal;
    public AxisType invertYawAxis = AxisType.Normal;
    public AxisType invertRollAxis = AxisType.Normal;

    public Inputs Inputs { get => _inputs; set => _inputs = value; }

    private Inputs _inputs;

    private void Awake()
    {
        _inputs = new Inputs();
        _inputs.Enable();
    }

    internal Vector3 MovementAxis => _inputs.Aircraft.Movement.ReadValue<Vector3>();

    internal float Yaw => _inputs.Aircraft.Yaw.ReadValue<float>() * (float)invertYawAxis;

    internal float Roll => _inputs.Aircraft.Roll.ReadValue<float>() * (float)invertRollAxis;

    internal float Pitch => _inputs.Aircraft.Pitch.ReadValue<float>() * (float)invertPitchAxis;

    internal bool IsRolling => Roll != 0;
    internal bool IsPitching => Pitch != 0;
    internal bool IsYawing => Yaw != 0;

    internal bool IsInputRotating => IsRolling && IsPitching && IsYawing;
}
