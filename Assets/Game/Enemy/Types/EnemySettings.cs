using UnityEngine;
using UnityUtils;
using Utilities;

[System.Serializable]

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Scriptable Objects/EnemySettings")]
public class EnemySettings : FlyweightSettings {
    [ReadOnly]
    public string nameString;
    public BaseStats baseStats;
    
    public override Flyweight Create() {
        var go = Instantiate(prefab);
        go.SetActive(false);
        go.name = prefab.name;

        var flyweight = go.GetOrAdd<EnemyNormal>();
        flyweight.settings = this;

        return flyweight;
    }


    private void OnValidate() {
        // Automatically set nameString to the asset's name
        if (string.IsNullOrEmpty(nameString) || nameString != name) {
            nameString = name;
        }
    }
}
