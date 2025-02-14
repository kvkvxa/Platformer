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

    private float _health = 100f;

    public bool IsAlive => _health > 0;

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
    }

    private void UpdateAnimationStates()
    {
        _playerAnimator.UpdateRunningState(_playerMover.IsMoving());
        _playerAnimator.UpdateJumpingState(_playerMover.IsJumping());
    }
}
