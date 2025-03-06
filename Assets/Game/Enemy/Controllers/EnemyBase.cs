using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {
    protected BaseStats enemyBaseStats;

    private Dictionary<StatType, float> statTypesToMultiplier;

    protected virtual void Awake() {
        statTypesToMultiplier = new Dictionary<StatType, float>();

        foreach (StatType statType in System.Enum.GetValues(typeof(StatType))) {
            statTypesToMultiplier.Add(statType, 1f);
        }
    }

    public virtual void Setup(BaseStats baseStats) {
        enemyBaseStats = baseStats;
    }
}

