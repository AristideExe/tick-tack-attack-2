using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAim : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private CinemachineThirdPersonFollow cinemachine;
    
    [Header("Settings")]
    [SerializeField] private float defaultCameraDistance = 2.29f;
    [SerializeField] private float aimCameraDistance = 1.5f;
    [SerializeField] private float aimSpeed = 10f;
    
    private InputAction _aim;

    private void Awake()
    {
        _aim = InputSystem.actions.FindAction("Aim");
    }

    private void Update()
    {
        if (_aim.inProgress)
        {
            float distance = Mathf.Lerp(cinemachine.CameraDistance, aimCameraDistance, aimSpeed * Time.deltaTime);
            cinemachine.CameraDistance = distance;
            if (Math.Abs(aimCameraDistance - distance) < 0.01f) cinemachine.CameraDistance = aimCameraDistance;
        }
        else
        {
            float distance = Mathf.Lerp(cinemachine.CameraDistance, defaultCameraDistance, aimSpeed * Time.deltaTime);
            cinemachine.CameraDistance = distance;
            if (Math.Abs(defaultCameraDistance - distance) < 0.01f) cinemachine.CameraDistance = defaultCameraDistance;
            
        }
    }
}
