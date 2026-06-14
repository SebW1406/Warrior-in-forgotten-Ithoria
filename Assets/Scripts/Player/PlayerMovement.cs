using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float speed = 5f;
    private Rigidbody2D myRigidbody;
    private Vector2 change;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        change = InputSystem.actions["Move"].ReadValue<Vector2>();
        transform.Translate(change * speed * Time.deltaTime);
    }
}
