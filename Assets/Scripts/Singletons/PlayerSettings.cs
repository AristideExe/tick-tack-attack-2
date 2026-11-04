using UnityEngine;

namespace Singletons
{
    public class PlayerSettings : MonoBehaviour
    {
        private static PlayerSettings _instance;

        [SerializeField] private float mouseSensitivityX;
        [SerializeField] private float mouseSensitivityY;
        [SerializeField] private float controllerSensitivityX;
        [SerializeField] private float controllerSensitivityY;
    
        public static PlayerSettings Instance => _instance;
        public float MouseSensitivityX => mouseSensitivityX;
        public float MouseSensitivityY => mouseSensitivityY;
        public float ControllerSensitivityX => controllerSensitivityX;
        public float ControllerSensitivityY => controllerSensitivityY;
    
        private void Start()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
