using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float FlySpeed;
    void Update()
    {
        transform.Translate(FlySpeed * Time.deltaTime * Vector3.up);
    }
}
