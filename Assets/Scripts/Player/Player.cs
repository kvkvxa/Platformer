using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private GroundChecker _groundChecker;

    private bool _hasJumpInput = false;
    private float _directionX = 0f;

    private void Update()
    {
        _directionX = _inputReader.GetDirectionX();
        _hasJumpInput = _inputReader.HasJumpInput();

        UpdateAnimationStates();
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_directionX);

        if (_playerMover.IsMoving() && Mathf.Abs(transform.localScale.x) > Mathf.Epsilon)
        {
            if (Mathf.Sign(_directionX) != Mathf.Sign(transform.localScale.x))
            {
                _playerMover.Flip();
            }
        }

        if (_hasJumpInput && _groundChecker.IsGrounded)
        {
            _playerMover.Jump();
            _hasJumpInput = false;
        }
    }

    private void UpdateAnimationStates()
    {
        bool isRunning = _playerMover.IsMoving();
        bool isJumping = !_groundChecker.IsGrounded;

        _playerAnimator.UpdateRunningState(isRunning);
        _playerAnimator.UpdateJumpingState(isJumping);
    }
}