using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _playerMover;

    private const string RunningAnimationParameter = "isRunning";
    private const string JumpingAnimationParameter = "isJumping";

    private void Update()
    {
        _animator.SetBool(RunningAnimationParameter, _playerMover.IsMoving());
        _animator.SetBool(JumpingAnimationParameter, _playerMover.IsGrounded == false);
    }
}