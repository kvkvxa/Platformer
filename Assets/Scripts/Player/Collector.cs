using System;
using UnityEngine;

public class Collector : MonoBehaviour, ICollectableVisitor
{
    public event Action<int> CoinCollected;
    public event Action<int> HealerCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectable collectable))
        {
            collectable.Accept(this);
        }
    }

    public void Visit(Coin coin)
    {
        CoinCollected?.Invoke(coin.Collect());
    }

    public void Visit(Healer healer)
    {
        HealerCollected?.Invoke(healer.Collect());
    }
}