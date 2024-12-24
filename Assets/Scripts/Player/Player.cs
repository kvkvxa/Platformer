using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _coinCollector.OnCoinCollected += AddCoin;
    }

    private void OnDisable()
    {
        _coinCollector.OnCoinCollected -= AddCoin;
    }

    private void AddCoin()
    {
        _wallet.IncreaseBalance();
    }
}