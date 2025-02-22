using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Healer : MonoBehaviour, ICollectable
{
    private int _healthPoints = 1;

    public int Collect()
    {
        gameObject.SetActive(false);

        return _healthPoints;
    }

    public void Accept(ICollectableVisitor visitor)
    {
        visitor.Visit(this);
    }
}