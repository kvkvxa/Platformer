using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour
{
    public Action OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(collider.gameObject);

            OnCoinCollected?.Invoke();
        }
    }
}
