using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float FireRate = 2f;
    private float _lastFireTime;
    public Transform[] GunsPosition;
    public Bullet BulletPrefab;
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
            Instantiate(BulletPrefab, guns.position, guns.rotation);
        }
    }
}
