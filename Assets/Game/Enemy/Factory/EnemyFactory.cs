using UnityEngine;

public abstract class EnemyFactory : ScriptableObject{
    public EnemyType enemyType;

    public abstract EnemyBase Create();
}

