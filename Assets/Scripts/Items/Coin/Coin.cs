using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    public int Score { get; private set; } = 1;

    public void OnCollected()
    {
        Collected?.Invoke(this);

        gameObject.SetActive(false);
    }
}