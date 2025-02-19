using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Sprite heartSprite;
    [SerializeField] private Image[] heartImages;

    private void Awake()
    {
        foreach (Image heartImage in heartImages)
        {
            heartImage.sprite = heartSprite;
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = i < currentHealth;
        }
    }
}
