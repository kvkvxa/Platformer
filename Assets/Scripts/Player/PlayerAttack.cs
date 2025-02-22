using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttacker
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private InputReader _inputReader;

    public int Damage { get; private set; } = 1;

    private void FixedUpdate()
    {
        if (_inputReader.HasAttackInput)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Bullet bullet = _bulletPool.GetBullet();
        bullet.transform.position = transform.position;

        float direction = Mathf.Sign(transform.localScale.x);
        bullet.SetDirection(direction);

        bullet.Hit += HandleHit;
    }

    public void Attack(IDamagable enemy)
    {
        enemy.TakeDamage(Damage);
    }

    private void HandleHit(Bullet bullet, Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamagable enemy))
        {
            Attack(enemy);
        }

        _bulletPool.ReleaseBullet(bullet);

        bullet.Hit -= HandleHit;
    }
}