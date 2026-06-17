using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject SwordHitBox;
    private float attackCooldown = 0.3f;
    

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.actions["Attack"].WasPressedThisFrame())
        {
            StartCoroutine(Attack()); // "StatCoroutine" -> Funktion wird nicht sofort komplett ausgeführt sondern über mehrere Frames hinweg
        }
    }

    IEnumerator Attack()
    {
        SwordHitBox.SetActive(true);
        yield return new WaitForSeconds(0.15f); // Zeit in der die Hitbox aktiv ist

        SwordHitBox.SetActive(false);
        yield return new WaitForSeconds(attackCooldown); // Cooldown bevor man wieder angreifen kann
    }
}
