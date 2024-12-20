using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _speed = 1f;
    private bool _willFall = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        _willFall = true;
    }

    public void Patrol()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, _rigidbody.linearVelocity.y);

        if (_willFall)
        {
            FlipSprite();
            _willFall = false;
        }
    }

    private void FlipSprite()
    {
        _speed = -_speed;

        transform.localScale = new Vector2(-(Mathf.Sign(_rigidbody.linearVelocity.x)), transform.localScale.y);
    }
}