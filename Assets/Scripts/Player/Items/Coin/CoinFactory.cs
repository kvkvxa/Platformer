using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public Coin CreateCoin =>
        Instantiate(_coinPrefab);
}