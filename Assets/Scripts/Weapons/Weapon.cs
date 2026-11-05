using System;
using System.Collections;
using Character;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons
{
    [RequireComponent(typeof(ThirdPersonCamera), typeof(CameraAim))]
    public class Weapon : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform weaponSocket;
        [SerializeField] private WeaponScriptableObject weaponData;

        public int Ammo => _ammo;
        public int Magazine => _magazine;
    
        private InputAction _fire;
        private InputAction _reload;
        private Camera _camera;
        private ThirdPersonCamera _thirdPersonCamera;
        private CameraAim _cameraAim;
        private GameObject _weapon;
        private float _delay;
        private int _ammo;
        private int _magazine;
        private bool _isReloading;

        private void Awake()
        {
            _fire = InputSystem.actions.FindAction("Attack");
            _reload = InputSystem.actions.FindAction("Reload");
            _camera = Camera.main;
            _thirdPersonCamera = GetComponent<ThirdPersonCamera>();
            _cameraAim = GetComponent<CameraAim>();
        }
        
        public void Start()
        {
            _ammo = weaponData.initialAmmo;
            _magazine = weaponData.magazineSize;
            SpawnWeaponModel();
        }

        private void SpawnWeaponModel()
        {
            _weapon = Instantiate(weaponData.prefab, weaponSocket.position, weaponSocket.rotation, weaponSocket);
            _weapon.transform.parent = weaponSocket.transform;
            _weapon.layer = gameObject.layer;
        }
        
        private void Update()
        {
            _delay -= Time.deltaTime;
            if (!_isReloading) weaponSocket.transform.localRotation = Quaternion.Euler(- _thirdPersonCamera.Pitch, 180f, 0f);
            
            if (weaponData.shootingDelay == ShootingDelay.Single)
            {
                if (_fire.WasPressedThisFrame() && _delay <= 0f && !_isReloading)
                {
                    StartCoroutine(Shoot());
                    _delay = weaponData.delay;
                }
            }
            else if (weaponData.shootingDelay == ShootingDelay.Auto && !_isReloading)
            {
                if (_fire.inProgress && _delay <= 0f)
                {
                    StartCoroutine(Shoot());
                    _delay = weaponData.delay;
                }
            }
            
            if (_reload.WasPressedThisFrame() && _magazine < weaponData.magazineSize && !_isReloading)
            {
                StartCoroutine(Reload());
                StartCoroutine(ReloadAnimation());
            }
        }

        private IEnumerator Shoot()
        {
            if (weaponData.shootingType == ShootingType.Burst)
            {
                for (int i = 0; i < 3; i++)
                {
                    Fire();
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else
            {
                Fire();
            }
        }

        private void Fire()
        {
            if (_magazine > 0)
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
                if (_cameraAim.IsAiming) _thirdPersonCamera.AddRecoil(weaponData.horizontalRecoil / 2, weaponData.verticalRecoil / 2);
                else _thirdPersonCamera.AddRecoil(weaponData.horizontalRecoil, weaponData.verticalRecoil);
            
                _magazine--;
            }
        }

        private IEnumerator Reload()
        {
            _isReloading = true;
            yield return new WaitForSeconds(weaponData.reloadDelay);
            int reloadSize = Mathf.Clamp(weaponData.magazineSize - _magazine, 0, _ammo);
            _ammo -= reloadSize;
            _magazine += reloadSize;
            _isReloading = false;
        }

        private IEnumerator ReloadAnimation()
        {
            float pitch = weaponSocket.transform.rotation.eulerAngles.x;
            while (_isReloading)
            {
                pitch += 5f;
                weaponSocket.transform.localRotation = Quaternion.Euler(pitch, 180f, 0f);
                yield return null;
            }
        }
    }
}
