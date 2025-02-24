using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _myRigidbody;

    public int Damage { get; private set; } = 50;
    public event Action<Bullet, Collider2D> GotHit;

    private float _speed = 10f;
    private float _direction = 1f;

    private void Update()
    {
        _myRigidbody.linearVelocity = new Vector2(_direction * _speed, _myRigidbody.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D triggeredBy)
    {
        GotHit?.Invoke(this, triggeredBy);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
    }
}
