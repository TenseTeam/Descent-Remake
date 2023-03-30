namespace ProjectDescent.UI
{
    using ProjectDescent.InputControllers;
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using System.Collections.Generic;

    [RequireComponent(typeof(MinimapInputsController))]
    public class MinimapController : MonoBehaviour
    {
        [Header("References")]
        public Camera cam;
        public Transform target;
        public Vector3 distanceOffset;
        public GameObject uiToDisable;
        public GameObject minimapUI;

        [Header("Camera Movement")]
        public float panningSpeed = 10f;
        public float rotationSpeed = 10f;

        [Header("Zoom")]
        public float zoomScale = 2f;

        [Header("Minimap Camera")]
        public float depthOnEnable = 1f;

        private float camStartDepth;
        private MinimapInputsController _inputs;
        public bool IsMapOpen { get; private set; }

        [field: SerializeField]
        public List<InputsController> InputsControllerToDisable { get; set; }


        private Vector3 _effectiveTargetPosition;

        private void Start()
        {
            _inputs = GetComponent<MinimapInputsController>();

            _inputs.Inputs.Minimap.OpenClose.performed += OpenMap;
            _inputs.Inputs.Minimap.Recenter.performed += RecenterTarget;

            camStartDepth = cam.depth;
            CameraSetup();
        }


        private void Update()
        {
            if(IsMapOpen)
                ManageCamera();
        }

        private void CameraSetup()
        {
            _effectiveTargetPosition = target.position;
            cam.transform.position = target.position + distanceOffset;
            cam.transform.LookAt(target);
        }

        private void ManageCamera()
        {
            RotateCamera();
            PanCamera();
            ZoomCamera();
        }


        private void RecenterTarget(InputAction.CallbackContext obj)
        {
            CameraSetup();
        }

        private void RotateCamera()
        {
            if (_inputs.IsRequestingZoom)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_effectiveTargetPosition - cam.transform.position);
                cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

                cam.transform.RotateAround(_effectiveTargetPosition, Vector3.up, -_inputs.Axes.x * rotationSpeed * Time.deltaTime);
                cam.transform.RotateAround(_effectiveTargetPosition, cam.transform.right, _inputs.Axes.y * rotationSpeed * Time.deltaTime);
            }
        }

        private void PanCamera()
        {
            if (_inputs.IsPanning)
            {
                cam.transform.Translate(_inputs.Axes.x * panningSpeed * Time.deltaTime, _inputs.Axes.y * panningSpeed * Time.deltaTime, 0f, Space.Self);
                _effectiveTargetPosition += cam.transform.right * _inputs.Axes.x * panningSpeed * Time.deltaTime + cam.transform.up * _inputs.Axes.y * panningSpeed * Time.deltaTime;
            }
        }

        private void ZoomCamera()
        {
            Vector3 zoom = new Vector3(0, 0, _inputs.Zoom * zoomScale);
            zoom = cam.transform.forward * zoom.z;
            cam.transform.localPosition += zoom * Time.deltaTime;
        }

        private void OpenMap(InputAction.CallbackContext obj)
        {
            if (!IsMapOpen)
            {
                TogglePlayerInputs(true);
                cam.depth = depthOnEnable;
                IsMapOpen = true;
                uiToDisable.SetActive(false);
                minimapUI.SetActive(true);
                CameraSetup();
                return;
            }

            TogglePlayerInputs(false);
            minimapUI.SetActive(false);
            uiToDisable.SetActive(true);
            cam.depth = camStartDepth;
            IsMapOpen = false;
        }

        private void TogglePlayerInputs(bool enable)
        {
            foreach (InputsController inp in InputsControllerToDisable)
            {
                if (enable)
                    inp.Disable();
                else
                    inp.Enable();
            }
        }

    }
}