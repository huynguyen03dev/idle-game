using UnityEngine;

[CreateAssetMenu(fileName = "EnemyNormalFactory", menuName = "Enemy Factory/EnemyNormalFactory")]
public class EnemyNormalFactory : EnemyFactory {
    public override EnemyBase Create() {
        EnemyNormal enemy = Instantiate(enemyType.enemyPrefab, Vector3.zero, Quaternion.identity).GetComponent<EnemyNormal>();
        enemy.Setup(enemyType.baseStats);
        return enemy;
    }
}