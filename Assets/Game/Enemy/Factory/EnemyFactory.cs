using UnityEngine;

public interface IEnemyFactory
{
    public EnemySettings enemyType { get; }

    EnemyBase Create();
}

public abstract class EnemyFactory : FlyweightFactory {
    public EnemySettings settings { get; }

}

