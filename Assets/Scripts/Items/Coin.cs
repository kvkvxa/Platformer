using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public int Score { get; private set; } = 1;
}