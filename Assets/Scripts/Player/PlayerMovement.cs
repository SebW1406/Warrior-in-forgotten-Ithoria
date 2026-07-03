using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed = 5f; // Geschwindigkeit des Characters
    private Vector2 change; // Wird benötigt für das neue Inputsystem

    private Vector2 knockbackDir;
    private Vector2 knockbackWallCheck;
    private float knockbackTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (knockbackTimer > 0) // Solange der Timer größer als 0 ist, ist die normale Steuerung gesperrt
        {
            //&& !Physics2D.OverlapCircle(knockbackDir, 0.1f, LayerMask.GetMask("Wall"))
            bool wallKnockback = Physics2D.OverlapCircle(knockbackDir, 0.5f, LayerMask.GetMask("Wall"));

            if (!wallKnockback)
            {
                transform.Translate(knockbackDir * Time.deltaTime); // Der Rückstoß wird an den Spieler angewendent
            }
            
            knockbackTimer -= Time.deltaTime; // Herunterzählen des Timers
        }

        // Movement
        change = InputSystem.actions["Move"].ReadValue<Vector2>();
        Vector2 movingTo = (Vector2)transform.position + (change * speed * Time.deltaTime);

        bool wall = Physics2D.OverlapCircle(movingTo, 0.1f, LayerMask.GetMask("Wall"));

        if (!wall)
        {
            transform.position = movingTo;
        }
        
    }

    public void ApplyKnockback(Vector2 force) // Die Funktion wird im "EnemyStats" Script aufgerufen
    {
        knockbackDir = force; // Die Variablen die oben gesetzt wurden erhalten hier ihre Werte
        knockbackTimer = 0.15f; // Dauer des Rückstoßes
    }
}
