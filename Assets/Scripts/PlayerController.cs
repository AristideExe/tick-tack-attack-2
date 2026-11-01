using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;
    
    private InputAction _move;
    private InputAction _jump;
    
    private CharacterController _controller;
    private Vector3 _velocity;

    private void Awake()
    {
        _move = InputSystem.actions.FindAction("Move");
        _jump = InputSystem.actions.FindAction("Jump");
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 moveInput = _move.ReadValue<Vector2>();
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (_controller.isGrounded) _velocity.y = -2f;
        if (_jump.WasPressedThisFrame() && _controller.isGrounded) _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        _velocity.y += gravity * Time.deltaTime;
        
        Vector3 motion = moveDirection * speed + Vector3.up * _velocity.y;
        _controller.Move(motion * Time.deltaTime);
    }
}
