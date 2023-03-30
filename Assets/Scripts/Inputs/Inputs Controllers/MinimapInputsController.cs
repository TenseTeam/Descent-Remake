namespace ProjectDescent.InputControllers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MinimapInputsController : InputsController
    {
        public Inputs Inputs { get; private set; }

        protected virtual void Awake()
        {
            Inputs = new Inputs();
            Enable();
        }

        public override void Enable()
        {
            Inputs.Enable();
        }

        public override void Disable()
        {
            Inputs.Disable();
        }

        public bool IsPanning => Inputs.Minimap.Pan.IsPressed();
        public bool IsRequestingZoom => Inputs.Minimap.RequestZoom.IsPressed();
        public Vector3 Axes => Inputs.Minimap.Axes.ReadValue<Vector2>();
        public float Zoom => Inputs.Minimap.Zoom.ReadValue<float>();
    }
}
