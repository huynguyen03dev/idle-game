using UnityEngine;

public abstract class ShooterBase : MonoBehaviour {
    [SerializeField] protected Transform bulletPrefab;

    protected IEntity target;

    public virtual void Shoot(Vector3 bulletSpawnPos) {
        

    }

    public virtual void SetTarget(IEntity target) {
        this.target = target;
    }
}