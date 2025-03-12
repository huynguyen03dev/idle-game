using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum StatCategory {
    None,
    Attack,
    Defense,
    Economy,
    Defender,
}

public enum StatType {
    AttackDamage,
    AttackSpeed,
    AttackRange,
    Health,
    HealthRegen,
    CritChance,
    CritDamage,
    MoveSpeed,
}

public interface IStat {
}

[Serializable]
public class Stat<T> : IStat {
    public StatType statType;
    public StatCategory statCategory;
    public T value;
    public AnimationCurve statCurve;
}


[Serializable]
[CreateAssetMenu(fileName = "BaseStats", menuName = "Scriptable Objects/BaseStats")]
public class BaseStats : ScriptableObject {
    public Stat<float> attackDamage;
    public Stat<float> attackSpeed;
    public Stat<float> attackRange;
    public Stat<int> health;
    public Stat<float> healthRegen;  // per second
    public Stat<float> critChance;
    public Stat<float> critDamage;
    public Stat<float> moveSpeed;

    public IStat GetBaseStat(StatType statType) {
        switch (statType) {
            case StatType.AttackDamage:
                return attackDamage;
            case StatType.AttackSpeed:
                return attackSpeed;
            case StatType.AttackRange:
                return attackRange;
            case StatType.Health:
                return health;
            case StatType.HealthRegen:
                return healthRegen;
            case StatType.CritChance:
                return critChance;
            case StatType.CritDamage:
                return critDamage;
            case StatType.MoveSpeed:
                return moveSpeed;
        }

        Debug.LogError("StatType not found in BaseStats");
        return null;
    }

    
}
