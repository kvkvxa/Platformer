using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<int> OnHealerCollected;
    public event Action<int> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            OnCoinCollected?.Invoke(coin.Collect());
        }

        if (collision.TryGetComponent(out Healer healer))
        {
            OnHealerCollected?.Invoke(healer.Collect());
        }
    }
}
