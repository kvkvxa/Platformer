using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public float invincibilityDuration = 2f;
    public float blinkInterval = 0.1f;

    private bool isBlinking = false;

    public void StartBlink()
    {
        if (isBlinking == false)
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        isBlinking = true;
        float endTime = Time.time + invincibilityDuration;

        while (Time.time < endTime)
        {
            _sprite.enabled = !_sprite.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        _sprite.enabled = true;
        isBlinking = false;
    }
}