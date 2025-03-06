using UnityEngine;
using UnityUtils;

[System.Serializable]

[CreateAssetMenu(fileName = "EnemyType", menuName = "Scriptable Objects/EnemyType")]
public class EnemyType : ScriptableObject {
    [ReadOnly]
    public string nameString;
    public BaseStats baseStats;
    public Transform enemyPrefab;
    
    private void OnValidate() {
        // Automatically set nameString to the asset's name
        if (string.IsNullOrEmpty(nameString) || nameString != name) {
            nameString = name;
        }
    }
}
