using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour
{
    public event Action<Coin> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(collider.gameObject);

            CoinCollected?.Invoke(coin);
        }
    }
}
