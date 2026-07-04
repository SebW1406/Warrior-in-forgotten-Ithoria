using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 3; // Lebenspunkte des Gegner
    [SerializeField] float knockbackPower = 10f; // Stärke des Rückstoßes
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SwordHitBox")) // Wenn die SchwertHitBox auf den Gegner trifft werden Leben abgezogen vom Gegner
        {
            health--;

            if (health <= 0)
            {
                if (gameObject.name == "Kakamaus")
                {
                    animator.CrossFade("Kakamaus Death", 0.1f);
                }
                GameObject.Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Player"))
        {
            if (gameObject.name == "Schurke")
            {
                animator.CrossFade("Schurke Attack", 0.1f);
            }
            float diffrenzPosY = collision.transform.position.y - transform.position.y; // Differenz der Position vom Gegner und Spieler in der Y Koordinate
            float diffrenzPosX = collision.transform.position.x - transform.position.x; // Differenz der Position vom Gegner und Spieler in der X Koordinate

            float winkel = Mathf.Atan2(diffrenzPosY, diffrenzPosX); // Berechnung des Winkel

            float sin = Mathf.Sin(winkel); // Berechnung Sinus
            float cos = Mathf.Cos(winkel); // Berechnung Cosinus

            Vector2 knockback = new Vector2(cos, sin) * knockbackPower; // Berechnung des Rückstoßes

            collision.GetComponent<PlayerMovement>().ApplyKnockback(knockback);
        }
    }
    
}
