using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 3f;

    private IMovementStrategy _currentStrategy;
    private Patrol _patrol;
    private Following _follow;

    private void Awake()
    {
        _patrol = new Patrol(_rigidbody, _waypoints, _speed);
        _follow = new Following(_rigidbody, _player, _speed);
        _currentStrategy = _patrol;
    }

    private void Update()
    {
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        float distanceToPlayer = Vector2.Distance(_rigidbody.position, _player.position);

        if (distanceToPlayer <= _detectionRadius)
        {
            _currentStrategy = _follow;
        }
        else
        {
            _currentStrategy = _patrol;
        }
    }

    public void Move()
    {
        _currentStrategy.Move();
    }

    public void Stop()
    {
        _currentStrategy.Stop();
    }
}
