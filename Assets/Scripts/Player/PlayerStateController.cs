using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    private bool _isActive = true;

    public bool IsActive => _isActive;

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
    }
}
