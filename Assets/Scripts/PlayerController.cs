using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet BulletPrefab;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}
