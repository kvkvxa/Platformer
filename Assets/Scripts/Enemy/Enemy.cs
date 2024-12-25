using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;

    private void FixedUpdate()
    {
        _mover.Move();
    }
}