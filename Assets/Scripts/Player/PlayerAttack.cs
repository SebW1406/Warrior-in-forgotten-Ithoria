
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject SwordHitBox;
    private float attackCooldown = 0.8f;

    private Vector2 pos;
    private Vector2 movingToaaaaa;


    [SerializeField] Animator animator;

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
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.4f); // Zeit in der die Hitbox aktiv ist

        SwordHitBox.SetActive(false);
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(attackCooldown); // Cooldown bevor man wieder angreifen kann
    }

    public void HasXOrYChanged(Vector2 currentpos)
    {
        pos = currentpos;
    }
}
