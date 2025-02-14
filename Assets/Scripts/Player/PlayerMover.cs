using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerStateController _stateController;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    private float _directionX;
    private bool _isJumping;

    private float _threshold = 0.01f;

    private void Update()
    {
        _directionX = _inputReader.GetMove();

        _isJumping = _inputReader.GetJump();
    }

    private void FixedUpdate()
    {
        if (_stateController.IsActive == false)
            return;

        Move(_directionX);

        if (_isJumping)
            Jump();
    }


    public bool IsMoving() => Mathf.Abs(_rigidbody.linearVelocity.x) > _threshold;
    public bool IsJumping() => Mathf.Abs(_rigidbody.linearVelocity.y) > _threshold;

    private void Move(float directionX)
    {
        _rigidbody.linearVelocity = new Vector2(directionX * _moveSpeed, _rigidbody.linearVelocity.y);

        Flip(directionX);
    }

    private void Jump()
    {
        if(_groundChecker.IsGrounded == false)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Flip(float directionX)
    {
        if (Mathf.Sign(directionX) != Mathf.Sign(transform.localScale.x))
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
