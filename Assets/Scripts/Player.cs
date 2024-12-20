using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CoinCollector _coinCollector;

    private int _score = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _coinCollector.Collect(collider, ref _score);
    }

    private void Update()
    {
        _playerMovement.Run();
        _playerMovement.Jump();
    }
}
