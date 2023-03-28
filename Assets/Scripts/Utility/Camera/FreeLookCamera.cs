using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private float _maxLookUpAngle = 80f;
    [SerializeField] private float _maxLookDownAngle = -80f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _maxLookDownAngle, _maxLookUpAngle);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.root.localRotation = Quaternion.Euler(0f, _yRotation, 0f);
    }
}
