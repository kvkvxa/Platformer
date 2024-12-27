using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _runningState = Animator.StringToHash("isRunning");
    private readonly int _jumpingState = Animator.StringToHash("isJumping");

    public void UpdateRunningState(bool isRunning)
    {
        _animator.SetBool(_runningState, isRunning);
    }

    public void UpdateJumpingState(bool isJumping)
    {
        _animator.SetBool(_jumpingState, isJumping);
    }
}