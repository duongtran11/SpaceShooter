using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
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

}
