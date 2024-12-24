using UnityEngine;

public class Patrol : EnemyMover
{
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;
    private Vector2 _currentWaypoint;
    private float _waypointReachDistance = 0.4f;

    private void Awake()
    {
        _currentWaypoint = _waypoints[0].position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        Vector2 directionToWaypoint = (_currentWaypoint - Rigidbody.position).normalized;
        Rigidbody.linearVelocity = directionToWaypoint * Speed;

        if (IsAtWaypoint())
        {
            MoveToNextWaypoint();
        }
    }

    private bool IsAtWaypoint()
    {
        return Rigidbody.position.IsEnoughClose(_currentWaypoint, _waypointReachDistance);
    }

    private void MoveToNextWaypoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        _currentWaypoint = _waypoints[_currentWaypointIndex].position;
    }
}