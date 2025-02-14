using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public int Damage { get; private set; } = 50;
    public event Action<Bullet, Collider2D> Hit;

    private float _speed = 10f;
    private float _direction = 1f;

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime * Vector3.right;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Hit?.Invoke(this, other);
    }
}
