using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private BlinkEffect _blinkEffect;
    [SerializeField] private PlayerStateController _stateController;
    [SerializeField] private KnockbackHandler _knockbackHandler;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private Collector _collector;

    private int _health = 3;

    public bool IsAlive => _health > 0;

    private void OnEnable()
    {
        _collector.OnHealerCollected += Heal;
    }

    private void OnDisable()
    {
        _collector.OnHealerCollected -= Heal;
    }

    private void Update()
    {
        UpdateAnimationStates();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            _stateController.SetActive(false);
            _playerAnimator.UpdateDeathState(true);
        }
        else
        {
            _knockbackHandler.StartKnockback();
            _blinkEffect.StartBlink();
        }

        _healthUI.UpdateHealth(_health);
    }

    private void Heal(int healthPoints)
    {
        _health += healthPoints;

        if (_health > 3)
        {
            _health = 3;
        }

        _healthUI.UpdateHealth(_health);
    }

    private void UpdateAnimationStates()
    {
        _playerAnimator.UpdateRunningState(_playerMover.IsMoving());
        _playerAnimator.UpdateJumpingState(_playerMover.IsJumping());
    }
}
