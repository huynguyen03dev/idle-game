using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]  
public abstract class SensorBase : MonoBehaviour {
    public Action<IEntity> OnTargetChanged;

    protected CircleCollider2D circleDetector;

    protected IEntity currentTarget;

    protected IEntity ownerEntity;

    protected float range;

    public virtual void Setup(float range, IEntity owner) {
        this.range = range;
        ownerEntity = owner;
    }

    protected virtual void SetTarget(IEntity target) {
        currentTarget = target;
        OnTargetChanged?.Invoke(target);
    }
}

public class SensorFindClosest : SensorBase {
    private void Update() {
        if (ownerEntity == null) {
            return;
        }

        IEntity closetTarget = FindClosetTarget();

        if (closetTarget != currentTarget) {
            SetTarget(closetTarget);
        }
    }

    private IEntity FindClosetTarget() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        IEntity closetTarget = null;
        float minDistance = float.MaxValue;

        foreach (var collider in colliders) {
            IEntity entity = collider.GetComponent<IEntity>();
            
            if (entity == null) {
                continue;
            }

            if (entity.Type == ownerEntity.Type) {
                continue;
            }

            if (entity.Type != ownerEntity.Type) {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < minDistance) {
                    minDistance = distance;
                    closetTarget = entity;
                }
            }
        }

        return closetTarget;
    }
}