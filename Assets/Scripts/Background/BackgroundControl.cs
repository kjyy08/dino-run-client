using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    // ��� �̵� �ӵ� ���� (1~200 ���� �� ���� ����)
    [SerializeField] private BackgroundData backgroundData;

    // ����� �ݺ��� ������ �� (�ػ� ���� ����)
    [SerializeField] float posValue;

    // ����� �ʱ� ��ġ
    Vector2 startPos;

    // ����� ���ο� ��ġ ���� ����
    float newPos;

    void Start()
    {
        startPos = transform.position; // ���� ������Ʈ�� �ʱ� ��ġ ����
    }

    void Update()
    {
        // Mathf.Repeat�� ����Ͽ� posValue ���� �ʰ����� �ʵ��� �ݺ����� �� ���
        newPos = Mathf.Repeat(Time.time * backgroundData.BackgroundSpeed, posValue);

        // ����� �������� �̵�, �ʱ� ��ġ���� newPos��ŭ �̵���Ŵ
        transform.position = startPos + Vector2.left * newPos;
    }
}
