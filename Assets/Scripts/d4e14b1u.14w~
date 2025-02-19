using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;

    private bool _isPatrolling = true;

    private void FixedUpdate()
    {
        if (_isPatrolling)
        {
            _patrol.Move();
        }
    }
}