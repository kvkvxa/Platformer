using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public void Collect(Collider2D collider, ref int score)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(collider.gameObject);

            score += 1;
            ShowScore(score);
        }
    }

    public void ShowScore(int score)
    {
        print(score);
    }
}
