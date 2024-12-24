using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string _axisX = "Horizontal";
    private readonly KeyCode _jumpKey = KeyCode.UpArrow;

    public float GetDirectionX()
    {
        return Input.GetAxis(_axisX);
    }

    public bool HasJumpInput()
    {
        return Input.GetKeyDown(_jumpKey);
    }
}