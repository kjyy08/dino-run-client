using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CactusManager : MonoBehaviour
{
    public Transform spawnPoint;

    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float maxSpawnInterval = 4f;
    private bool isSpawning = false;     // ��ֹ� ���� ����

    private enum CACTUS_TYPE
    {
        CACTUS_A = 0, CACTUS_B, CACTUS_C
    }

    // ��ֹ� ���� ����
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnObstacles());
        }
    }

    // ��ֹ� ���� �������� ����
    private IEnumerator SpawnObstacles()
    {
        while (isSpawning)
        {
            // ObjectPool���� �������� PooledObject ����
            int randomIndex = Random.Range(0, ObjectPool.Instance.objectPool.Count);
            string cactusType = ObjectPool.Instance.objectPool[randomIndex].poolItemName;

            // ��ֹ� ����
            GameObject obstacle = ObjectPool.Instance.PopFromPool(cactusType);
            obstacle.transform.position = spawnPoint.position;
            obstacle.SetActive(true);

            // ���� �ð� �������� ����
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }
}
