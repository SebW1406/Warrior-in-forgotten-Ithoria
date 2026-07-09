using UnityEditor.Build;
using UnityEngine;

public class Door : MonoBehaviour
{
    private int keysPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwordHitBox"))
        {
            keysPlayer = collision.GetComponentInParent<PlayerStats>().GetKeys();
            Debug.Log("Schlüssel Spieler: " +  keysPlayer);

            if (keysPlayer > 0) 
            {
                Destroy(gameObject);
                collision.GetComponentInParent<PlayerStats>().UseKey();
            }
        }
    }

}
