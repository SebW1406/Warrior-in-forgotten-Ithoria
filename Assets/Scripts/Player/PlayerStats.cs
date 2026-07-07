using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private float iFrames = 0.5f;
    [SerializeField] Animator animator;

    [SerializeField] int keysPlayer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera.main.GetComponent<KameraMovement>().Player(transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHitBox"))
        {
            health--;
            if (health <= 0)
            {
                GetComponent<CapsuleCollider2D>().enabled = false;
                animator.CrossFade("Player Death", 0.1f);
                Time.timeScale = 0f;
            }
        }
    }

    IEnumerator IFrames()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(iFrames);

        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    public void KeyPickUp(int keys)
    {
        keysPlayer += keys;
    }
}