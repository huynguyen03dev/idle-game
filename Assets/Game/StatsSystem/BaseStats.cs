using UnityEngine;

[CreateAssetMenu(fileName = "BaseStats", menuName = "Scriptable Objects/BaseStats")]
public class BaseStats : ScriptableObject {
    public float attackDamage;
    public float attackSpeed;
    public float attackRange;
    public float health;
    public float healthRegen;  // per second
    public float critChance;
    public float critDamage;
}
