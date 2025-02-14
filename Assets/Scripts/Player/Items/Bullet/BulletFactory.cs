using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    public Bullet Create() => Instantiate(_bulletPrefab);
}