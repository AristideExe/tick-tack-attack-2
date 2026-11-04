using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FloatingDamageUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]  private TextMeshProUGUI damageText;
    
        [Header("Settings")]
        [SerializeField] private float initialYVelocity = 7f;
        [SerializeField] private float initialXVelocity = 3;
        [SerializeField] private float lifeTime = 0.8f;
    
        private Rigidbody2D _rigidBody;
        private Camera _camera;
    
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            damageText = GetComponentInChildren<TextMeshProUGUI>();
            _camera = Camera.main;
        }

        private void Start()
        {
            _rigidBody.linearVelocity = new Vector2(Random.Range(-initialXVelocity, initialXVelocity), initialYVelocity);
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(_camera.transform.position - transform.position);
        }
    
        public void SetDamage(float damage)
        {
            damageText.text = damage.ToString();
        }
    }
}
