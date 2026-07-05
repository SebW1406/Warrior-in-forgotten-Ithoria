using UnityEngine;

public class SpawnerKey : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    int keysToSpawn = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy") == false && keysToSpawn > 0)
        {
            Spawn();
            keysToSpawn--;
        }
    }

    void Spawn()
    {
        Instantiate(keyPrefab, Vector3.zero, Quaternion.identity);
    }
}
