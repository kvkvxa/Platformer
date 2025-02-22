using UnityEngine;

public class Follower : IMovementStrategy
{
    private readonly Rigidbody2D _myRigidbody;
    private readonly float _speed;
    private Transform _target;

    public Follower(Rigidbody2D rigidbody, float speed)
    {
        _myRigidbody = rigidbody;
        _speed = speed;
    }

    public void Move()
    {
        if (_target != null)
        {
            Vector2 direction = (_target.position.ToVector2() - _myRigidbody.position).normalized;
            _myRigidbody.linearVelocity = direction * _speed;
        }
    }

    public void Stop()
    {
        _myRigidbody.linearVelocity = new Vector2(0, _myRigidbody.linearVelocity.y);
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
