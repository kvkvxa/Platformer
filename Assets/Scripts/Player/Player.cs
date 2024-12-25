using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _coinCollector.CoinCollected += AddCoin;
    }

    private void OnDisable()
    {
        _coinCollector.CoinCollected -= AddCoin;
    }

    private void AddCoin(Coin coin)
    {
        _wallet.IncreaseBalance(coin.Score);
    }
}