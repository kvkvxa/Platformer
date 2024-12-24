using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerMover _playerMover;

    private void Update()
    {
        if (Mathf.Sign(_playerMover.DirectionX) != Mathf.Sign(_spriteRenderer.transform.localScale.x) && _playerMover.IsMoving())
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        Vector3 newScale = _spriteRenderer.transform.localScale;
        newScale.x *= -1; 
        _spriteRenderer.transform.localScale = newScale;
    }
}