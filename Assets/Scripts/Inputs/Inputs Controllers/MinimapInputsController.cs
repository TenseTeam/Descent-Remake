namespace ProjectDescent.InputsManagement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MinimapInputsController : MonoBehaviour
    {
        public Inputs Inputs { get; private set; }

        private void Awake()
        {
            Inputs = new Inputs();
            Inputs.Enable();
        }



        public Vector3 Axes => Inputs.Minimap.Axes.ReadValue<Vector2>();
        public float Zoom => Inputs.Minimap.Zoom.ReadValue<float>();
        public bool IsPanning => Inputs.Minimap.Pan.ReadValue<float>() > 0.5f;
    }
}
