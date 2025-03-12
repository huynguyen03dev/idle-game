
using System;
using System.Collections;
using Systems.Persistence;
using UnityEngine;
using Utilities;



public class HqController : MonoBehaviour, IBind<PlayerData>, IEntity  {
    [SerializeField] private PlayerData playerData;

    [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();
    public EntityType Type { get; set; }

    public HealthSystem healthSystem { get; set; }

    private SensorBase sensor;

    private IEntity target;

    private void Awake() {
        Type = EntityType.Friendly;
        sensor = GetComponentInChildren<SensorBase>();
    }

    IEnumerator Start()
    {
        yield return Helpers.GetWaitForSeconds(0.01f);
        Debug.Log(playerData.PlayerBaseStats.health.value);
        sensor.Setup(playerData.PlayerBaseStats.attackRange.value, this);
    }

    private void OnEnable() {
        sensor.OnTargetChanged += OnTargetChanged;
    }

    private void OnDisable() {
        sensor.OnTargetChanged -= OnTargetChanged;
    }

    private void OnTargetChanged(IEntity entity)
    {
        target = entity;
    }

    public void Bind(PlayerData data)
    {
        playerData = data;
        playerData.Id = Id;
    }

}
