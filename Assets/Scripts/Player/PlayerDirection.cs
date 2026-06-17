using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDirection : MonoBehaviour
{

    public Transform SwordHitBox; // Hier wird das GameObject "SwordHitBox" eingefügt
    private Vector2 change;

    // Update is called once per frame
    void Update()
    {

        change = InputSystem.actions["Move"].ReadValue<Vector2>();

        if (change.x > 0) // Rechts
        {
            SwordHitBox.localPosition = new Vector2(1.1f, 0f); 
            SwordHitBox.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (change.x < 0) // Links
        {
            SwordHitBox.localPosition = new Vector2(-1.1f, 0f); 
            SwordHitBox.localRotation = Quaternion.Euler(0, 0, -180);
        }
        
        if (change.y > 0) // Oben
        {
            SwordHitBox.localPosition = new Vector2(0f, 1.4f); 
            SwordHitBox.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (change.y < 0) // Unten
        { 
            SwordHitBox.localPosition = new Vector2(0f, -1.4f); 
            SwordHitBox.localRotation = Quaternion.Euler(0, 0, -90);
        }
        
    }
}
