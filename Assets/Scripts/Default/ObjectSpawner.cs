using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab; 
    public float spawnInterval = 2f; // Интервал времени между созданием объектов
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();

            timer = 0f;
        }
    }

    void SpawnObject()
    {
        GameObject cube = Instantiate(prefab, transform.position, transform.rotation);
        cube.AddComponent<SimpleRotate>().rotationSpeed = 100;
        cube.AddComponent<MoveToPosition>().target = GetRandomVector3();
    }
    
    private Vector3 GetRandomVector3()
    {
        float x = Random.Range(0, 12f);
        float y = Random.Range(0, 12f);
        float z = Random.Range(0, 12f);

        return new Vector3(x, y, z); 
    }
}
