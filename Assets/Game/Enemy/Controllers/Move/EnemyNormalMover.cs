using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.XR;
using Utilities;

public class EnemyNormalMover : MonoBehaviour, IEnemyMover {
    [ShowInInspector] private bool isMoving;
    private Vector3 destination;
    [ShowInInspector] private float moveSpeed;

    private Rigidbody2D rb;

    private void Awake() {
        isMoving = false;
        rb = gameObject.GetOrAdd<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update() {
        if (!isMoving)
            return;

        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 direction = (destination - transform.position).normalized;
        rb.linearVelocity =  moveSpeed * direction;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        rb.linearVelocity = Vector2.zero;
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}
