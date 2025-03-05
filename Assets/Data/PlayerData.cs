using System.Collections.Generic;
using UnityEngine;

public enum StatType {
    AttackDamage,
    AttackSpeed,
    AttackRange,
    Health,
    HealthRegen,
    CritChance,
    CritDamage
}

public class PlayerData {
    public BaseStats PlayerBaseStats { get; private set; }

    private Dictionary<StatType, int> statTypesToUpgradeTimes;

    private int goldAmount;
    private int gemAmount;

    public PlayerData(BaseStats testBaseStats = null) {
        if (testBaseStats != null) {
            PlayerBaseStats = testBaseStats;
        } else {
            PlayerBaseStats = Resources.Load<BaseStats>("PlayerBaseStats");
        }

        statTypesToUpgradeTimes = new Dictionary<StatType, int>();
        foreach (StatType statType in System.Enum.GetValues(typeof(StatType))) {
            statTypesToUpgradeTimes.Add(statType, 0);
        }
    }

    public int GetStatUpgradeTimes(StatType statType) {
        return statTypesToUpgradeTimes[statType];
    }
}
