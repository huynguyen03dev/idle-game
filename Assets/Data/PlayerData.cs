using System.Collections.Generic;
using UnityEngine;
using Systems.Persistence;
using System;
using System.Linq;

[Serializable]
public class StatTypeUpgradeTime {
    public StatType statType;
    public int upgradeTimes;
}

[Serializable]
public class PlayerData : ISaveable {
    [field: SerializeField] public SerializableGuid Id { get; set; }

    public BaseStats PlayerBaseStats { get; private set; }

    [SerializeField] private List<StatTypeUpgradeTime> statInfo;

    private int goldAmount;
    private int gemAmount;

    public PlayerData() {
        InitializeStatUpgradeTimes();
    }

    private void InitializeStatUpgradeTimes()
    {
        statInfo = new List<StatTypeUpgradeTime>();
        foreach (StatType statType in System.Enum.GetValues(typeof(StatType)))
        {
            statInfo.Add(new StatTypeUpgradeTime { statType = statType, upgradeTimes = 0});
        }
    }

    public void LoadBaseStats(BaseStats baseStats = null) {
        if (baseStats == null) {
            PlayerBaseStats = Resources.Load<BaseStats>("PlayerBaseStats");
        } else {
            PlayerBaseStats = baseStats;
        }
    }

    public int GetStatUpgradeTimes(StatType statType) {
        return statInfo.FirstOrDefault(statInfo => statInfo.statType == statType).upgradeTimes;
    }

    public void SetStatUpgradeTimes(StatType statType, int times) {
        statInfo.FirstOrDefault(statInfo => statInfo.statType == statType).upgradeTimes = times;
    }

    public float CaculateStat(StatType statType) {
        IStat stat = PlayerBaseStats.GetBaseStat(statType);

        if (stat is Stat<float> floatStat) {
            return floatStat.value * (1 + floatStat.statCurve.Evaluate(GetStatUpgradeTimes(statType) * 0.1f));
        }

        if (stat is Stat<int> intStat) {
            return intStat.value + intStat.statCurve.Evaluate(GetStatUpgradeTimes(statType));
        }

        Debug.LogError("Stat<T> not implemented in PlayerData");
        return 0f;
    }
}
