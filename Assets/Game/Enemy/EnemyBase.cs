using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {
    [field: SerializeField] public BaseStats EnemyBaseStats { get; private set; }

    private Dictionary<StatType, float> statTypesToMultiplier;

    protected virtual void Awake() {
        statTypesToMultiplier = new Dictionary<StatType, float>();

        foreach (StatType statType in System.Enum.GetValues(typeof(StatType))) {
            statTypesToMultiplier.Add(statType, 1f);
        }
    }
}
