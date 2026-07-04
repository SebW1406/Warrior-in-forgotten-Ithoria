
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject SwordHitBoxDownUp;
    public GameObject SwordHitBoxLeftRight;
    private float attackCooldown = 0.8f;
    private int onOffSwitch = 0;

    private Vector2 pos;

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
        if (pos.y == 1)
        {
            animator.CrossFade("Player Attack back", 0.1f);
            SwordHitBoxDownUp.SetActive(true);
            onOffSwitch = 1;
        }
        else if (pos.y == -1)
        {
            animator.CrossFade("Player Attack front", 0.1f);
            SwordHitBoxDownUp.SetActive(true);
            onOffSwitch = 1;
            
        }
        else if (pos.x == 1)
        {
            animator.CrossFade("Player Attack", 0.1f);
            GetComponent<SpriteRenderer>().flipX = false;
            SwordHitBoxLeftRight.SetActive(true);
            onOffSwitch = 2;

        }
        else if (pos.x == -1)
        {
            animator.CrossFade("Player Attack", 0.1f);
            GetComponent<SpriteRenderer>().flipX = true;
            SwordHitBoxLeftRight.SetActive(true);
            onOffSwitch = 2;

        }

        yield return new WaitForSeconds(0.4f); // Zeit in der die Hitbox aktiv ist

        if (onOffSwitch == 1)
        {
            SwordHitBoxDownUp.SetActive(false);
        }
        if (onOffSwitch == 2)
        {
            SwordHitBoxLeftRight.SetActive(false);
        }
        yield return new WaitForSeconds(attackCooldown); // Cooldown bevor man wieder angreifen kann
    }
    

    public void HasXOrYChanged(Vector2 currentpos)
    {
        pos = currentpos;
    }

}
