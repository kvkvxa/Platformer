using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _scorePerCoin = 1;

    public void Collect(Collider2D collider, ref int score)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(collider.gameObject);

            score += _scorePerCoin;
            ShowScore(score);
        }
    }

    public void ShowScore(int score)
    {
        print(score);
    }
}
