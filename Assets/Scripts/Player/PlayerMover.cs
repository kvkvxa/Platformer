using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 7f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _groundCheckCircleCenter;
    [SerializeField] private LayerMask _groundLayer;

    private bool _hasJumpInput = false;
    private float _grounCheckCircleRadius = 1f;
    private float _restingSpeed = Mathf.Epsilon;
    private float _directionX = 0f;

    public bool IsGrounded { get; private set; } = false;

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundCheckCircleCenter.position, _grounCheckCircleRadius, _groundLayer);

        Move(_directionX);

        if (Mathf.Sign(_directionX) != Mathf.Sign(transform.localScale.x) && IsMoving())
        {
            Flip();
        }

        if (_hasJumpInput && IsGrounded)
        {
            Jump();
            _hasJumpInput = false;
        }
    }

    private void Update()
    {
        _directionX = _inputReader.GetDirectionX();
        _hasJumpInput = _inputReader.HasJumpInput();
    }

    public bool IsMoving()
    {
        return Mathf.Approximately(_directionX, _restingSpeed) == false;
    }

    private void Move(float directionX)
    {
        _rigidbody.linearVelocity = new Vector2(directionX * _speed, _rigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}