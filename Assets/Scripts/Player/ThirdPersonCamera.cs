using Singletons;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Player
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform cameraTarget;
    
        [Header("Settings")]
        [SerializeField] float minPitch = -40f;
        [SerializeField] float maxPitch = 70f;

        public float Pitch => pitch;
        
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
        
            bool isGamepad = _look.activeControl?.device is Gamepad;
            PlayerSettings settings = PlayerSettings.Instance;
            float sensitivityX = isGamepad ? settings.ControllerSensitivityX : settings.MouseSensitivityX / 10;
            float sensitivityY = isGamepad ? settings.ControllerSensitivityY : settings.MouseSensitivityY / 10;
        
            transform.Rotate(0f, delta.x * sensitivityX, 0f, Space.World);
            pitch = Mathf.Clamp(pitch - delta.y * sensitivityY, minPitch, maxPitch);
            cameraTarget.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }
    
        public void AddRecoil(float horizontal, float vertical)
        {
            pitch = Mathf.Clamp(pitch - vertical, minPitch, maxPitch);
            cameraTarget.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            transform.Rotate(0f, Random.Range(-horizontal, horizontal), 0f);
        }
    }
}
