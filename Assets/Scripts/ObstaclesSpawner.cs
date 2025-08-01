using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] private float offset = 1.5f;
    [SerializeField] public GameObject removerPoint;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnTime;
        SpawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject spawnedObstacles = Instantiate(obstaclePrefab, new Vector3(transform.position.x, RandomPosition() ,0), Quaternion.identity);
            spawnedObstacles.GetComponent<Obstacles>().SetIntanceReference(removerPoint);
            timer = spawnTime;
        }
    }
    
    private float RandomPosition()
    {
        float offset_1 = transform.position.y + offset;
        float offset_2 = transform.position.y - offset;
        return Random.Range(offset_1, offset_2);
    }
}
