using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public abstract class BulletBase : MonoBehaviour {
    protected float damage;

    public void Setup(float damage) {
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        IEntity entity = other.GetComponent<IEntity>();
        if (entity != null) {
            entity.healthSystem.TakeDamage(damage);
        }
    }
}