using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed = 5f; // Geschwindigkeit des Characters
    private Vector2 change; // Wird benötigt für das neue Inputsystem

    private Vector2 knockbackForce; // Richtung
    private Vector2 bewegung; // Richtung * Frames
    private Vector2 knockbackZielPos; // Jetzige Pos * Bewegung


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
            bewegung = knockbackForce * Time.deltaTime;
            knockbackZielPos = (Vector2)transform.position + bewegung;

            bool wallKnockback = Physics2D.OverlapCircle(knockbackZielPos, 0.5f, LayerMask.GetMask("Wall")); // Wenn beim Knockback eine Wand getroffen werden würde, dann stopt der Rückstoß

            if (!wallKnockback)
            {
                transform.Translate(knockbackForce * Time.deltaTime); // Der Rückstoß wird an den Spieler angewendent
            }
            
            knockbackTimer -= Time.deltaTime; // Herunterzählen des Timers
        }

        // Movement
        change = InputSystem.actions["Move"].ReadValue<Vector2>();
        Vector2 movingTo = (Vector2)transform.position + (change * speed * Time.deltaTime); // Wohin sich der Spieler bewegen wird

        bool wall = Physics2D.OverlapCircle(movingTo, 0.1f, LayerMask.GetMask("Wall")); // Wenn die Postion wo sich der Spieler bewegen möchte eine Wand ist, stopt die bewegung

        if (!wall)
        {
            transform.position = movingTo; // Wenn keine Collission mit der Wand stattfindet dann update die Position des Spielers
        }
        
    }

    public void ApplyKnockback(Vector2 force) // Die Funktion wird im "EnemyStats" Script aufgerufen
    {
        knockbackForce = force; // Die Variablen die oben gesetzt wurden erhalten hier ihre Werte
        knockbackTimer = 0.15f; // Dauer des Rückstoßes
    }
}
