using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    private float _invincibilityDuration = 2f;
    private float _blinkInterval = 0.1f;

    private WaitForSeconds _waitForBlink;

    private bool _isBlinking = false;

    public void Awake()
    {
        _waitForBlink = new WaitForSeconds(_blinkInterval);
    }

    public void StartBlink()
    {
        if (_isBlinking == false)
        {
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        _isBlinking = true;
        float endTime = Time.time + _invincibilityDuration;

        while (Time.time < endTime)
        {
            _sprite.enabled = !_sprite.enabled;
            yield return _waitForBlink;
        }

        _sprite.enabled = true;
        _isBlinking = false;
    }
}