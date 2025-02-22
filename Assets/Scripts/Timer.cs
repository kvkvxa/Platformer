using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour
{
    private Action _callback;
    private Coroutine _timerCoroutine;
    private WaitForSeconds _wait;

    public void StartTimer(float duration, Action callback)
    {
        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);

        _callback = callback;
        _wait = new WaitForSeconds(duration);
        _timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return _wait;
        _callback?.Invoke();
    }

    public void StopTimer()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }
}