using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed = 5f; // Geschwindigkeit des Characters
    private Vector2 change; // Wird benötigt für das neue Inputsystem

    private Vector2 knockbackForce;
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
            transform.Translate(knockbackForce * Time.deltaTime); // Der Rückstoß wird an den Spieler angewendent
            knockbackTimer -= Time.deltaTime; // Herunterzählen des Timers
        }

        // Movement
        change = InputSystem.actions["Move"].ReadValue<Vector2>();
        transform.Translate(change * speed * Time.deltaTime);
    }

    public void ApplyKnockback(Vector2 force) // Die Funktion wird im "EnemyStats" Script aufgerufen
    {
        knockbackForce = force; // Die Variablen die oben gesetzt wurden erhalten hier ihre Werte
        knockbackTimer = 0.15f; // Dauer des Rückstoßes
    }
}
