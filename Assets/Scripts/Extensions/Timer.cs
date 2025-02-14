using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour
{
    private Action _callback;
    private Coroutine _timerCoroutine;

    public void StartTimer(float duration, Action callback)
    {
        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);

        _callback = callback;
        _timerCoroutine = StartCoroutine(TimerCoroutine(duration));
    }

    private IEnumerator TimerCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
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