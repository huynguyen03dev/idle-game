using UnityEngine;

public interface IEnemyMover {
    void SetDestination(Vector3 destination);
    void StartMoving();
    void StopMoving();   
    void SetMoveSpeed(float moveSpeed); 
}
