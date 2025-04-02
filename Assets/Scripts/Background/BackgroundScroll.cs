using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private BackgroundData backgroundData;
    [SerializeField] private float resetPositionX;

    Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * backgroundData.BackgroundSpeed * Time.deltaTime);

        if (transform.position.x < resetPositionX)
        {
            transform.position = startPos;
        }
    }
}
