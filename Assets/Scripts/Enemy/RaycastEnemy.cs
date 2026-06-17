using UnityEngine;

public class RaycastEnemy : MonoBehaviour
{
    [SerializeField] private float maxdistanceRaycast = 50f;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Hier wird geschaut ob es ein GameObject mit dem Tag "Player" gibt
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 origin = transform.position;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        int mask = LayerMask.GetMask("Player", "Default"); // Hier wird eingestellt welche Tags berücksichtigt werden

        float distance = Vector2.Distance(origin, player.transform.position);
        //Debug.Log(distance);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, maxdistanceRaycast, mask);

        if (hit.collider.CompareTag("Player") && distance <= 3f)
        {
            //Debug.Log("Treffer " + hit.collider.gameObject);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2.5f * Time.deltaTime);
        }
        else
        {
             //Debug.Log(hit.collider.gameObject);
        }

        Debug.DrawRay(origin, direction, Color.yellow);

    }
}
