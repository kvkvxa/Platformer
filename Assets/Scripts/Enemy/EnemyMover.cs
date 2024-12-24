using UnityEngine;

public abstract class EnemyMover : MonoBehaviour
{
    [field: SerializeField]
    protected Rigidbody2D Rigidbody;

    protected float Speed { get; private set; } = 1f;

    public abstract void Move();
}