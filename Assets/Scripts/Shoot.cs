using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform weaponSocket;
    [SerializeField] private WeaponScriptableObject weaponData;
    
    private InputAction _fire;
    private Camera _camera;
    private float _delay;

    private void Awake()
    {
        _fire = InputSystem.actions.FindAction("Attack");
        _camera = Camera.main;
    }

    private void Update()
    {
        _delay -= Time.deltaTime;
        if (weaponData.shootingDelay == ShootingDelay.Single)
        {
            if (_fire.WasPressedThisFrame() && _delay <= 0f)
            {
                Fire();
                _delay = weaponData.delay;
            }
        }
        else if (weaponData.shootingDelay == ShootingDelay.Auto)
        {
            if (_fire.inProgress && _delay <= 0f)
            {
                Fire();
                _delay = weaponData.delay;
            }
        }
    }

    private void Fire()
    {
        Ray ray = _camera.ScreenPointToRay(_camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f)));
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Health health))
            {
                health.TakeDamage(weaponData.damage, gameObject);
            }
        }
    }
}
