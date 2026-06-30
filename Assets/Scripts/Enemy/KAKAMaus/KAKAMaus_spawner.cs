using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KAKAMaus_spawner : MonoBehaviour
{

    //Prefab-Kakamaus
    [SerializeField] private GameObject KakaMaus_Prefab;
    
    //spawn per sec
    [SerializeField] private float SpawnPerSecond = 2.5f;

    


    void Start()
    {
        StartCoroutine(SpawnerinSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawning per second
    IEnumerator SpawnerinSeconds()
    {
        while (true)
        {
            //yield return new WaitForSeconds(SpawnPerSecond); - animation

            SpawnObject();
            yield return new WaitForSeconds(SpawnPerSecond);
        }
    }

    void SpawnObject()
    {
        Instantiate(KakaMaus_Prefab, transform.position, Quaternion.identity);
    }

}

