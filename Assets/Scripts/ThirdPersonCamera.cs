using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform cameraTarget;
    
    [Header("Settings")]
    [SerializeField] float sensitivity = 0.1f;       
    [SerializeField] float minPitch = -40f;
    [SerializeField] float maxPitch = 70f;

    private InputAction _look;
    private float pitch;

    private void Awake()
    {
        _look = InputSystem.actions.FindAction("Look");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 delta = _look.ReadValue<Vector2>();
        transform.Rotate(0f, delta.x * sensitivity, 0f, Space.World);
        pitch = Mathf.Clamp(pitch - delta.y * sensitivity, minPitch, maxPitch);
        cameraTarget.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
    
    public void AddRecoil(float horizontal, float vertical)
    {
        pitch = Mathf.Clamp(pitch - vertical, minPitch, maxPitch);
        cameraTarget.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.Rotate(0f, Random.Range(-horizontal, horizontal), 0f);
    }
}
