using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxHealth;

    public float HealthPercent => _health / maxHealth;
    
    private float _health;

    private void Start()
    {
        _health = maxHealth;
    }

    public void TakeDamage(float damage, GameObject attacker)
    {
        _health -= damage;
        if (_health <= 0) Die(attacker);
    }

    private void Die(GameObject attacker)
    {
        Destroy(gameObject);
    }
}
