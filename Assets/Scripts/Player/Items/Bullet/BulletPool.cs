using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private BulletFactory _bulletFactory;
    [SerializeField] private int _poolSize = 10;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(
            createFunc: CreatePooledItem,
            actionOnGet: bullet => bullet.gameObject.SetActive(true),
            actionOnRelease: bullet => bullet.gameObject.SetActive(false),
            actionOnDestroy: bullet => Destroy(bullet.gameObject),
            defaultCapacity: _poolSize,
            maxSize: _poolSize
        );
    }

    public Bullet GetBullet()
    {
        return _bulletPool.Get();
    }

    public void ReleaseBullet(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }

    private Bullet CreatePooledItem()
    {
        return _bulletFactory.Create();
    }
}