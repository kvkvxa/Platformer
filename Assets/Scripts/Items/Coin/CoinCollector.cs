using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            coin.Collected += AddCoin;

            coin.OnCollected();
        }
    }

    private void AddCoin(Coin coin)
    {
        _wallet.IncreaseBalance(coin.Score);

        coin.Collected -= AddCoin;
    }
}
