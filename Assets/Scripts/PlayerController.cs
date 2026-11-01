using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 5f;
    
    private InputAction _move;
    private CharacterController _controller;

    private void Awake()
    {
        _move = InputSystem.actions.FindAction("Move");
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 moveInput = _move.ReadValue<Vector2>();
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        _controller.Move(moveDirection * (speed * Time.deltaTime));
    }
}
