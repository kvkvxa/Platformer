using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;

    private void Update()
    {
        _enemyMovement.Patrol();
    }
}