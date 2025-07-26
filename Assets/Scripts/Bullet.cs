using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float FlySpeed;
    void Update()
    {
        var newPosition = transform.position;
        newPosition.y += FlySpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
