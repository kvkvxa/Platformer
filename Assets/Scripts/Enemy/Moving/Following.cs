using UnityEngine;

public class Following : IMovementStrategy
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Rigidbody2D _player;
    private readonly float _speed;

    public Following(Rigidbody2D rigidbody, Rigidbody2D player, float speed)
    {
        _rigidbody = rigidbody;
        _player = player;
        _speed = speed;
    }

    public void Move()
    {
        if (_player == null)
            return;

        Vector2 direction = (_player.position - _rigidbody.position).normalized;

        _rigidbody.linearVelocity = new Vector2(direction.x * _speed, _rigidbody.linearVelocity.y);
    }

    public void Stop()
    {
        _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
    }
}
