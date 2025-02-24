using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private ControlLocker _controlLocker;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    private float _threshold = 0.01f;

    private void FixedUpdate()
    {
        if (_controlLocker.IsActive == false)
            return;

        Move(_inputReader.DirectionX);

        if (_inputReader.HasJumpInput)
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
        if (Mathf.Sign(directionX) != Mathf.Sign(transform.forward.x))
        {
            transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + 180f, 0f);
        }
    }
}
