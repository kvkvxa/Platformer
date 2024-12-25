using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _playerMover;

    private int _runningState = Animator.StringToHash("isRunning");
    private int _jumpingState = Animator.StringToHash("isJumping");

    private void Update()
    {
        _animator.SetBool(_runningState, _playerMover.IsMoving());
        _animator.SetBool(_jumpingState, _playerMover.IsGrounded == false);
    }
}