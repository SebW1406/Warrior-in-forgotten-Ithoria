using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KAKAMaus_spawner : MonoBehaviour
{

    //Prefab-Kakamaus
    [SerializeField] private GameObject KakaMaus_Prefab;
    
    //spawn per sec
    [SerializeField] private float SpawnPerSecond = 2.5f;

    [SerializeField] private Tilemap tilemap;
    Vector3Int cellPosition;
    Vector3 spawnPoint;

    void Start()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(transform.localPosition);
        spawnPoint = tilemap.GetCellCenterWorld(cellPosition);
        //StartCoroutine(SpawnerinSeconds());

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile != null && tile.name == "Normal room wall left hole") // && tile.name == "KakamausSpawner"
            {
                //Debug.Log("Tile gefunden: " + tile.name);
                Vector2 worldPos = tilemap.GetCellCenterWorld(pos);
                StartCoroutine(SpawnerinSeconds(worldPos));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawning per second
    IEnumerator SpawnerinSeconds(Vector2 tilePos)
    {
        while (true)
        {
            //yield return new WaitForSeconds(SpawnPerSecond); - animation

            SpawnObject(tilePos);
            yield return new WaitForSeconds(SpawnPerSecond);
        }
    }

    void SpawnObject(Vector2 tilePos)
    {
        //Debug.Log("Spawning:" + KakaMaus_Prefab);
        Instantiate(KakaMaus_Prefab, tilePos, Quaternion.identity);
    }
}