namespace ProjectDescent.UI.Minimap
{
    using ProjectDescent.InputControllers;
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(MinimapInputsController))]
    public class MinimapController : MonoBehaviour
    {
        [Header("References")]
        public Camera cam;
        public Transform target;
        public Vector3 distanceOffset;

        [Header("Camera Movement")]
        public float rotationSpeed = 10f;

        [Header("Zoom")]
        public float zoomScale = 2f;

        [Header("Minimap Camera")]
        public float depthOnEnable = 1f;

        private float camStartDepth;
        private MinimapInputsController _inputs;
        public bool IsMapOpen { get; private set; }

        private void Start()
        {
            _inputs = GetComponent<MinimapInputsController>();

            _inputs.Inputs.Minimap.OpenClose.performed += OpenMap;

            camStartDepth = cam.depth;
            CameraSetup();
        }

        private void Update()
        {
            ManageCamera();
        }

        private void CameraSetup()
        {
            cam.transform.LookAt(target);
            cam.transform.position = target.position + distanceOffset;
        }

        private void ManageCamera()
        {
            RotateCamera();
            ZoomCamera();
        }

        private void RotateCamera()
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.position - cam.transform.position);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            cam.transform.RotateAround(target.position, Vector3.up, -_inputs.Axes.x * rotationSpeed * Time.deltaTime);
            cam.transform.RotateAround(target.position, cam.transform.right, _inputs.Axes.y * rotationSpeed * Time.deltaTime);
        }

        private void ZoomCamera()
        {
            Vector3 zoom = new Vector3(0, 0, _inputs.Zoom * zoomScale);
            zoom = cam.transform.forward * zoom.z * Time.deltaTime;
            cam.transform.localPosition += zoom;
        }

        private void OpenMap(InputAction.CallbackContext obj)
        {
            if (!IsMapOpen)
            {
                cam.depth = depthOnEnable;
                IsMapOpen = true;
                return;
            }

            cam.depth = camStartDepth;
            IsMapOpen = false;
        }
    }
}