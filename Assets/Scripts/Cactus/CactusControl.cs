using UnityEngine;

public class CactusControl : MonoBehaviour
{
    [SerializeField] private BackgroundData backgroundData;
    [SerializeField] private float resetPositionX;
    [SerializeField] private string poolItemName;

    // 배경의 초기 위치
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
            ObjectPool.Instance.PushToPool(poolItemName, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
