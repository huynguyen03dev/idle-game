using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public abstract class EnemyBase : Flyweight, IEntity {
    new EnemySettings settings => (EnemySettings) base.settings;

    protected BaseStats enemyBaseStats;
    protected IEnemyMover enemyMover;
    protected Vector3 hqPosition;
    protected Dictionary<StatType, float> statTypesToMultiplier;
    protected CircleCollider2D circleCollider2D;

    public EntityType Type { get; set; }

    public HealthSystem healthSystem { get; private set; }

    protected virtual void Awake() {
        healthSystem = gameObject.GetOrAdd<HealthSystem>();
        enemyMover = GetComponent<IEnemyMover>();
        circleCollider2D = gameObject.GetOrAdd<CircleCollider2D>();
    }

    private void OnEnable() {
        healthSystem.OnDead += OnDead;
    }

    private void OnDisable() {
        healthSystem.OnDead -= OnDead;
    }

    protected virtual void Start() {
        hqPosition = HqManager.Instance.GetHqController().transform.position;
        Setup();
    }

    public virtual void Setup() {
        Type = EntityType.Enemy;
        enemyBaseStats = settings.baseStats;

        healthSystem.Setup(enemyBaseStats.health.value, enemyBaseStats.healthRegen.value);
        statTypesToMultiplier = new Dictionary<StatType, float>();

        foreach (StatType statType in System.Enum.GetValues(typeof(StatType))) {
            statTypesToMultiplier.Add(statType, 1f);
        }

        // Setup enemy mover
        circleCollider2D.radius = enemyBaseStats.attackRange.value;
        enemyMover.SetDestination(HqManager.Instance.GetHqController().transform.position);
        enemyMover.SetMoveSpeed(enemyBaseStats.moveSpeed.value);
        enemyMover.StartMoving();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent(out HqController hqController)) {
            enemyMover.StopMoving();
        }
    }

    protected virtual void OnDead() {
        Destroy(gameObject);
    }
}

