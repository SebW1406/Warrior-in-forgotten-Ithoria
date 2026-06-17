using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 3; // Lebenspunkte des Gegner

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("SwordHitBox")) // Wenn die SchwertHitBox auf den Gegner trifft werden Leben abgezogen vom Gegner
        {
            health --;
                        
            if (health <= 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

}
