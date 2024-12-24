using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private void Awake()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Instantiate(_coin, spawnPoint.position, Quaternion.identity);
        }
    }
}