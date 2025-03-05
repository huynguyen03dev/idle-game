using UnityEngine;
using UnityUtils;

public class EnemyManager : Singleton<EnemyManager> {
    public Transform EnemyPrefab;

    [SerializeField] private Transform enemyContainer;

    

    public void SpawnEnemy(Vector3 spawnPosition) {
        var enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity, enemyContainer);
    }    
}
