using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Healer : MonoBehaviour
{
    private int _healthPoints = 1;

    public int Collect()
    {
        gameObject.SetActive(false);

        return _healthPoints;
    }
}