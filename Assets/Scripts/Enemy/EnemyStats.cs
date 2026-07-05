using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 3; // Lebenspunkte des Gegner
    [SerializeField] float knockbackPower = 10f; // Stärke des Rückstoßes an Spieler
    [SerializeField] Animator animator;

    Vector2 knockbackForce;
    Vector2 bewegung;
    Vector2 knockbackZielPos;
    float knockbackTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (knockbackTimer > 0f)
        {
            knockbackTimer -= Time.deltaTime;
            bewegung = knockbackForce * Time.deltaTime;
            knockbackZielPos = (Vector2)transform.position + bewegung;


            bool wallKnockback = Physics2D.OverlapCircle(knockbackZielPos, 0.5f, LayerMask.GetMask("Wall")); // Wenn beim Knockback eine Wand getroffen werden würde, dann stopt der Rückstoß

            if (!wallKnockback)
            {
                transform.position += (Vector3)knockbackZielPos * Time.deltaTime; // Der Rückstoß wird an den Gegner angewendent

            }
        }
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

            float diffrenzPosY = transform.position.y - collision.transform.position.y; // Differenz der Position vom Gegner und Spieler in der Y Koordinate
            float diffrenzPosX = transform.position.x - collision.transform.position.x; // Differenz der Position vom Gegner und Spieler in der X Koordinate

            float winkel = Mathf.Atan2(diffrenzPosY, diffrenzPosX); // Berechnung des Winkel

            float sin = Mathf.Sin(winkel); // Berechnung Sinus
            float cos = Mathf.Cos(winkel); // Berechnung Cosinus

            Vector2 knockback = new Vector2(cos, sin) * 4f; // Berechnung des Rückstoßes

            ApplyKnockbackEnemy(knockback);

            if (GetComponent<RaycastEnemy>() == true)
            {
                GetComponent<RaycastEnemy>().enabled = false;
                StartCoroutine(ReenableRaycastEnemy());
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

    IEnumerator ReenableRaycastEnemy() // Hier wird das Raycast Script (falls am Gegner vorhanden) kurz deaktiviert wenn man diesen getroffen hat
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<RaycastEnemy>().enabled = true;
    }

    public void ApplyKnockbackEnemy(Vector2 force) // Die Funktion wird im "EnemyStats" Script aufgerufen
    {
        knockbackForce = force; // Die Variablen die oben gesetzt wurden erhalten hier ihre Werte
        knockbackTimer = 0.15f;
    }
}
