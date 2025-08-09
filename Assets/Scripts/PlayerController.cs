using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float FireRate = 2f;
    private float _lastFireTime;
    public Transform[] GunsPosition;
    public Bullet BulletPrefab;
    private ObjectPooling<Bullet> _bulletPool;
    void Start()
    {
        _bulletPool = new ObjectPooling<Bullet>();
        _bulletPool.Initialize(20, BulletPrefab);
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
        if (Time.time > _lastFireTime + FireRate)
        {
            FireFromGuns();
            _lastFireTime = Time.time;
        }
    }
    private void FireFromGuns()
    {
        foreach (var guns in GunsPosition)
        {
            _bulletPool.GetFromPool(guns.position, guns.rotation);
        }
    }
}
