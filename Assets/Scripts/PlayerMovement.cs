using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    private readonly string _axisX = "Horizontal";
    private bool _isGrounded = false;
    private float _speed = 5f;
    private float _jumpSpeed = 5f;

    private void OnCollisionEnter2D()
    { 
        _isGrounded = true;
        _animator.SetBool("isJumping", false);
    }

    private void OnCollisionExit2D()
    {
        _isGrounded = false;
        _animator.SetBool("isJumping", true);
    }

    public void Run()
    {
        float playerInput = Input.GetAxis(_axisX);

        _rigidbody.linearVelocity = new Vector2(playerInput * _speed, _rigidbody.linearVelocity.y);

        bool isRunning = Mathf.Approximately(playerInput, 0f) == false;

        if (isRunning)
        {
            FlipSprite();
        }

        _animator.SetBool("isRunning", isRunning);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(_rigidbody.linearVelocity.x), transform.localScale.y);
    }
}