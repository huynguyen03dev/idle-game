using UnityEngine;
using UnityUtils;

public class EnemyManager : Singleton<EnemyManager> {
    public EnemyFactory enemyFactory;
    public Transform testSpawnPosition;

    [SerializeField] private Transform enemyContainer;

    public void SpawnEnemy(Vector3 spawnPosition) {
        var enemy = enemyFactory.Create();
        enemy.transform.position = spawnPosition;
        enemy.transform.SetParent(enemyContainer);
    }    
}
