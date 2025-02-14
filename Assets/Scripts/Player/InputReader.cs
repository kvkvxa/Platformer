using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string _axisX = "Horizontal";
    private readonly KeyCode _jumpKey = KeyCode.UpArrow;
    private readonly KeyCode _attackKey = KeyCode.Space;

    public float GetMove()
    {
        return Input.GetAxis(_axisX);
    }

    public bool GetJump()
    {
        return Input.GetKeyDown(_jumpKey);
    }

    public bool GetAttack()
    {
        return Input.GetKeyDown(_attackKey);
    }
}