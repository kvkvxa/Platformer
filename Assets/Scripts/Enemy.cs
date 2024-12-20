using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;

    private void Update()
    {
        enemyMovement.Patrol();
    }
}
