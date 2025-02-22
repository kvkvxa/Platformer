using UnityEngine;

public class EnemyMovingAI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _myRigidbody;

    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _detectionRadius = 3f;
    [SerializeField] private LayerMask _playerLayer;

    [SerializeField] private float _speed = 2f;

    private IMovementStrategy _currentStrategy;
    private Patroller _patroller;
    private Follower _follower;
    private Transform _player;

    private void Awake()
    {
        _patroller = new Patroller(_myRigidbody, _waypoints, _speed);
        _follower = new Follower(_myRigidbody, _speed);
        _currentStrategy = _patroller;
    }

    private void Update()
    {
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(_myRigidbody.position, _detectionRadius, _playerLayer);

        if (playerCollider != null)
        {
            _player = playerCollider.transform;
            _follower.SetTarget(_player);

            _currentStrategy = _follower;
        }
        else
        {
            _currentStrategy = _patroller;
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
