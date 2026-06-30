using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEditorInternal.VR;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class KAKAMaus_Enemy : MonoBehaviour
{
    [SerializeField] float MaxDistanceRay = 50f;


    //[SerializeField] private GameObject  KAKALoch_Exit;



    [SerializeField] private float SpeedofMaus = 3f;

    [SerializeField] private float ExitAnimationInSeconds = 3f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position , Vector2.right,Color.red);
        Debug.DrawRay(transform.position, Vector2.left, Color.yellow);
    



        // mask  = EnemySpanwer - layer
        int enemyMask = LayerMask.GetMask("EnemySpawner");

        //Position of Kakamaus
        Vector2 originalPosRight = (Vector2)transform.position + new Vector2(0.5f, 0);
        Vector2 originalPosLeft = (Vector2)transform.position + new Vector2(-0.5f, 0);

        //Raycast
        RaycastHit2D RayHitRight = Physics2D.Raycast(originalPosRight, Vector2.right, MaxDistanceRay, enemyMask);
        RaycastHit2D RayHitLeft = Physics2D.Raycast(originalPosLeft, Vector2.left, MaxDistanceRay, enemyMask);

        // Debug.Log(RayHit.collider.gameObject);

        //wenn Rayhit ollider drift mit name/TAG KLoch dann tu xyz

        
        if (RayHitRight.collider != null && RayHitRight.collider.CompareTag("KAKALoch_exit")) // Wenn Rayhit UNGLEICH 0 (Also wenn der was trifft, lol) UND Das GameObject den Tag "KAKALoch_Exit" hat dann ->
        {
            Debug.Log("RECHTS: " + RayHitRight.collider.gameObject);
            transform.position = Vector2.MoveTowards(transform.position, RayHitRight.collider.gameObject.transform.position, SpeedofMaus * Time.deltaTime);
            //Von der JETZIGEN POSITION zum GAMEOBJECT was vom Raycast getroffen wurde
        }

        else if (RayHitLeft.collider != null && RayHitLeft.collider.CompareTag("KAKALoch_exit"))
        {
            Debug.Log("LINKS: " + RayHitLeft.collider.gameObject);
            transform.position = Vector2.MoveTowards(transform.position, RayHitLeft.collider.gameObject.transform.position, SpeedofMaus * Time.deltaTime);
        }
        else
        {
            //anim Death
            Destroy(gameObject);
        }
        
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        StartCoroutine(MouseExiting());
    }

    IEnumerator MouseExiting()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
       
        // animation delay
        yield return new WaitForSeconds(ExitAnimationInSeconds);

        Destroy(gameObject);
     
        //  Destroy(Sprite_change);

    }

}
