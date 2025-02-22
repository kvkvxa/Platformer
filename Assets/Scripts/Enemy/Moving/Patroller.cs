using UnityEngine;

public class Patroller : IMovementStrategy
{
    private Rigidbody2D _myRigidbody;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed;
    private float _waypointReachDistance = 0.4f;

    public Patroller(Rigidbody2D rigidbody, Transform[] waypoints, float speed)
    {
        _myRigidbody = rigidbody;
        _waypoints = waypoints;
        _speed = speed;
    }

    public void Move()
    {
        Vector2 target = _waypoints[_currentWaypointIndex].position;
        Vector2 direction = (target - _myRigidbody.position).normalized;

        _myRigidbody.linearVelocity = direction * _speed;

        if (_myRigidbody.position.IsEnoughClose(target, _waypointReachDistance))
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
    }

    public void Stop()
    {
        _myRigidbody.linearVelocity = Vector2.zero;
    }
}
