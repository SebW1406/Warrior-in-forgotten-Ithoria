using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
    }

}
