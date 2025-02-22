using System;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Coin : MonoBehaviour, ICollectable
{
    private int _score = 1;

    public int Collect()
    {
        gameObject.SetActive(false);

        return _score;
    }

    public void Accept(ICollectableVisitor visitor)
    {
        visitor.Visit(this);
    }
}