using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string _axisX = "Horizontal";
    private readonly KeyCode _jumpKey = KeyCode.UpArrow;
    private readonly KeyCode _attackKey = KeyCode.Space;

    public float DirectionX { get; private set; }
    public bool HasJumpInput { get; private set; }
    public bool HasAttackInput { get; private set; }

    private void Update()
    {
        DirectionX = GetMove();
        HasJumpInput = GetJump();
        HasAttackInput = GetAttack();
    }

    private float GetMove()
    {
        return Input.GetAxis(_axisX);
    }

    private bool GetJump()
    {
        return Input.GetKeyDown(_jumpKey);
    }

    private bool GetAttack()
    {
        return Input.GetKeyDown(_attackKey);
    }
}