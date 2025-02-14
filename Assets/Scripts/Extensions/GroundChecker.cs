using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        IsGrounded = _collider.IsTouchingLayers(_groundLayer);
    }
}