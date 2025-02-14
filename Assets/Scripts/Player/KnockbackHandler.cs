using UnityEngine;

public class KnockbackHandler : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private float _knockbackDuration = 1f;
    private PlayerStateController _stateController;

    private void Awake()
    {
        _stateController = GetComponent<PlayerStateController>();
    }

    public void StartKnockback()
    {
        _stateController.SetActive(false);
        _timer.StartTimer(_knockbackDuration, EndKnockback);
    }

    private void EndKnockback()
    {
        _stateController.SetActive(true);
    }
}
