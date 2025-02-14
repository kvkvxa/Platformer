using UnityEngine;

public class Patrol : IMovementStrategy
{
    private Rigidbody2D _rigidbody;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed;
    private float _waypointReachDistance = 0.4f;

    public Patrol(Rigidbody2D rigidbody, Transform[] waypoints, float speed)
    {
        _rigidbody = rigidbody;
        _waypoints = waypoints;
        _speed = speed;
    }

    public void Move()
    {
        Vector2 target = _waypoints[_currentWaypointIndex].position;
        Vector2 direction = (target - _rigidbody.position).normalized;

        _rigidbody.linearVelocity = direction * _speed;

        if (_rigidbody.position.IsEnoughClose(target, _waypointReachDistance))
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
    }

    public void Stop()
    {
        _rigidbody.linearVelocity = Vector2.zero;
    }
}
