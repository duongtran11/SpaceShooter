using UnityEngine;

public class EngineBlink : MonoBehaviour
{
    private SpriteRenderer _sprite;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _sprite.enabled = !_sprite.enabled;
    }
}
