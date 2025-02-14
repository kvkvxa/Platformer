using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinFactory _coinFactory;
    [SerializeField] private Transform[] _spawnPoints;

    private void Awake()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Coin newCoin = _coinFactory.CreateCoin;
            newCoin.transform.position = spawnPoint.position;
        }
    }
}