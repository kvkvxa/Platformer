using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 7f;

    private float _restingSpeed = Mathf.Epsilon;

    public void Move(float directionX)
    {
        _rigidbody.linearVelocity = new Vector2(directionX * _speed, _rigidbody.linearVelocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public bool IsMoving()
    {
        return Mathf.Approximately(_rigidbody.linearVelocity.x, _restingSpeed) == false;
    }
}