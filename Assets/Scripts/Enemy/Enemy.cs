using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyMovingAI _enemyMovingAI;
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private BlinkEffect _blinkEffect;

    private readonly int _deathState = Animator.StringToHash("isDead");

    private int _health = 2;
    private bool _isDead = false;

    public bool IsAlive => _health > 0;

    private void FixedUpdate()
    {
        if (_groundChecker.IsGrounded)
        {
            if (!_isDead)
            {
                _enemyMovingAI.Move();
            }
            else
            {
                _enemyMovingAI.Stop();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _blinkEffect.StartBlink();

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        _animator.SetBool(_deathState, _isDead);
    }
}
