using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckCircleCenter;
    [SerializeField] private LayerMask _groundLayer;

    private float _grounCheckCircleRadius = 1f;

    public bool IsGrounded { get; private set; } = false;

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundCheckCircleCenter.position, _grounCheckCircleRadius, _groundLayer);
    }
}