using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int health = 3;
    [SerializeField] private float iFrames = 0.5f;
    [Space]

    [Header("Animator")]
    [SerializeField] Animator animator;
    [Space]

    // Canvas + UI
    private GameObject GameOverScreen;
    private Canvas GameCanvas;

    private TextMeshProUGUI healthUI;
    private GameObject GameUI;

    [Header("Items")]
    [SerializeField] int keyInventory;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera.main.GetComponent<KameraMovement>().Player(transform); // Hier wird die Kamera geholt für den Spieler

        // Canvas Stuff
        // Game Over
        if (GameCanvas == null) { GameCanvas = FindAnyObjectByType<Canvas>(); }
        Transform GOUI = GameCanvas.transform.Find("Gamer Over UI");
        if (GOUI != null) { GameOverScreen = GOUI.gameObject; }

        // Game UI
        Transform GUI = GameCanvas.transform.Find("Game UI");
        if (GUI != null) {  GameUI  = GUI.gameObject; }
        Transform healthTransform = GUI.transform.Find("HealthUI");
        if (healthTransform != null) { healthUI = healthTransform.GetComponent<TextMeshProUGUI>(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHitBox"))
        {
            health--;
            healthUI.text = $"Leben: {health}";


            if (collision.GetComponent<RaycastEnemy>() == true)
            {
                collision.GetComponent<RaycastEnemy>().GetHealth(health);
            }

            if (health <= 0)
            {
                GetComponent<CapsuleCollider2D>().enabled = false;
                animator.CrossFade("Player Death", 0.1f);
                Debug.Log("Screen Aktivieren: " + GameOverScreen.name);
                if (GameOverScreen != null)
                {
                    GameOverScreen.SetActive(true);
                }
                //Time.timeScale = 0f;
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
        keyInventory += keys;
    }

    public int GetKeys()
    {
        return keyInventory;
    }

    public void UseKey()
    {
        keyInventory--;
    }

}