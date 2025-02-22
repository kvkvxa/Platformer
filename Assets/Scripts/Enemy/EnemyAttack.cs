using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttack : MonoBehaviour, IAttacker
{
    [SerializeField] private float _knockbackForce = 2f;
    private float _verticalKnockbackOffset = 1f;

    public int Damage { get; private set; } = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamagable target))
        {
            Attack(target);

            if (collision.collider.TryGetComponent(out KnockbackHandler knockbackHandler) &&
                collision.collider.TryGetComponent(out Rigidbody2D playerRigidbody))
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                knockbackDirection.y += _verticalKnockbackOffset;
                knockbackDirection.Normalize();

                ApplyKnockback(playerRigidbody, knockbackDirection);

                knockbackHandler.StartKnockback();
            }
        }
    }

    public void Attack(IDamagable target)
    {
        if (target.IsAlive)
        {
            target.TakeDamage(Damage);
        }
    }

    private void ApplyKnockback(Rigidbody2D rigidbody, Vector2 direction)
    {
        rigidbody.AddForce(direction * _knockbackForce, ForceMode2D.Impulse);
    }
}
