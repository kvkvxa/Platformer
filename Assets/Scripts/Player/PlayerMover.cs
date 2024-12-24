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

    public bool IsGrounded { get; private set; } = false;
    public float DirectionX { get; private set; } = 0f;

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundCheckCircleCenter.position, _grounCheckCircleRadius, _groundLayer);

        Move(DirectionX);

        if (_hasJumpInput && IsGrounded)
        {
            Jump();
            _hasJumpInput = false;
        }
    }

    private void Update()
    {
        DirectionX = _inputReader.GetDirectionX();
        _hasJumpInput = _inputReader.HasJumpInput();
    }

    public bool IsMoving()
    {
        return Mathf.Approximately(DirectionX, _restingSpeed) == false;
    }

    private void Move(float directionX)
    {
        _rigidbody.linearVelocity = new Vector2(directionX * _speed, _rigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }
}
