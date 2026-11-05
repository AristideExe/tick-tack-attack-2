using Player;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawnPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
            enemy.SetActive(true);
        }
    }
}
