using UnityEngine;

public enum EntityType
{
    Friendly,
    Enemy
}

public interface IEntity {
    Transform transform { get; }
    EntityType Type { get; set; }
    HealthSystem healthSystem { get; }
}