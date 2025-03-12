using UnityEngine;
using UnityUtils;

public class EnemyManager : Singleton<EnemyManager> {
    public FlyweightSettings settings;
    public Transform testSpawnPosition;

    [SerializeField] private Transform enemyContainer;

    public void SpawnEnemy(Vector3 spawnPosition) {
        var enemy = FlyweightFactory.Spawn(settings);
        enemy.transform.position = spawnPosition;
        enemy.transform.SetParent(enemyContainer);
    }    
}
