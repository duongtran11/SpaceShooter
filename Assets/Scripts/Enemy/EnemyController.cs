using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _mainBody;
    [SerializeField] private HealthBar _healthBar;
    public float FlySpeed;
    public float _rotationSpeed;
    [HideInInspector]
    public FlyPath FlyPath;
    private int _nextPathIndex = 1;
    void Update()
    {
        if (FlyPath == null)
        {
            return;
        }
        if (transform.position != FlyPath[_nextPathIndex])
        {
            FlyToWaypoint(FlyPath[_nextPathIndex]);
            LookAtWaypoint(FlyPath[_nextPathIndex]);
        }
        else
        {
            _nextPathIndex++;
            if (_nextPathIndex >= FlyPath.Waypoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }
    void FlyToWaypoint(Vector3 waypoint)
    {
        var currentPos = transform.position;
        var nextPos = waypoint;
        transform.position = Vector3.MoveTowards(currentPos, nextPos, FlySpeed * Time.deltaTime);
    }
    void LookAtWaypoint(Vector3 waypoint)
    {
        var currentPos = transform.position;
        var lookDirection = waypoint - currentPos;

        var angle = Vector2.SignedAngle(Vector2.down, lookDirection);
        var targetRot = Quaternion.Euler(0f, 0f, angle);
        _mainBody.transform.rotation = Quaternion.Lerp(_mainBody.transform.rotation, targetRot, _rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _healthBar.DecreaseValue(10f);
        if (_healthBar.CurrentValue <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    public void OnDawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0f, -2f, 0f));
    }
}
