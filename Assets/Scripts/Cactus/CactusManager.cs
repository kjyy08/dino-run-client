using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CactusManager : MonoBehaviour
{
    public Transform spawnPoint;

    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float maxSpawnInterval = 4f;
    private bool isSpawning = false;     // 장애물 생성 여부

    private enum CACTUS_TYPE
    {
        CACTUS_A = 0, CACTUS_B, CACTUS_C
    }

    // 장애물 생성 시작
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnObstacles());
        }
    }

    // 장애물 일정 간격으로 생성
    private IEnumerator SpawnObstacles()
    {
        while (isSpawning)
        {
            // ObjectPool에서 랜덤으로 PooledObject 선택
            int randomIndex = Random.Range(0, ObjectPool.Instance.objectPool.Count);
            string cactusType = ObjectPool.Instance.objectPool[randomIndex].poolItemName;

            // 장애물 생성
            GameObject obstacle = ObjectPool.Instance.PopFromPool(cactusType);
            obstacle.transform.position = spawnPoint.position;
            obstacle.SetActive(true);

            // 일정 시간 간격으로 생성
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }
}
