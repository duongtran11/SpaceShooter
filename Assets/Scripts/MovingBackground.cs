using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _backGrounds;
    [SerializeField]
    private float _movingSpeed = 2f;
    private float _backGroundHeight;
    private Camera _camera;
    private float _cameraBottomEdge;

    void Awake()
    {
        _backGroundHeight = _backGrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
        _camera = Camera.main;
        _cameraBottomEdge = _camera.transform.position.y - _camera.orthographicSize;
    }
    void Update()
    {
        foreach (var backGround in _backGrounds)
        {
            var bgPos = backGround.transform.position;
            backGround.transform.position += _movingSpeed * Time.deltaTime * Vector3.down;
            if (bgPos.y + _backGroundHeight / 2 < _cameraBottomEdge)
            {
                float topBG = GetTopBackground();
                backGround.transform.position = new Vector3(bgPos.x, _backGroundHeight + topBG, bgPos.z);
            }
        }
    }
    float GetTopBackground()
    {
        var maxPos = 0f;
        foreach (var backGround in _backGrounds)
        {
            if (backGround.transform.position.y > maxPos)
            {
                maxPos = backGround.transform.position.y;
            }
        }
        return maxPos;
    }
}
               