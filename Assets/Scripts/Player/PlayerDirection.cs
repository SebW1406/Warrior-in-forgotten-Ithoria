using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDirection : MonoBehaviour
{

    public Transform SwordHitBoxDownUp; // Hier wird das GameObject "SwordHitBoxDownUp" eingefügt
    public Transform SwordHitBoxLeftRight; 
    private Vector2 change;

    // Update is called once per frame
    void Update()
    {

        change = InputSystem.actions["Move"].ReadValue<Vector2>();

        if (change.x > 0) // Rechts
        {
            SwordHitBoxLeftRight.localPosition = new Vector2(1.1f, 0f);
            SwordHitBoxLeftRight.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (change.x < 0) // Links
        {
            SwordHitBoxLeftRight.localPosition = new Vector2(-1.1f, 0f);
            SwordHitBoxLeftRight.localRotation = Quaternion.Euler(0, 0, -180);
        }
        
        if (change.y > 0) // Oben
        {
            SwordHitBoxDownUp.localPosition = new Vector2(0f, 1.4f);
            SwordHitBoxDownUp.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (change.y < 0) // Unten
        {
            SwordHitBoxDownUp.localPosition = new Vector2(0f, -1.4f);
            SwordHitBoxDownUp.localRotation = Quaternion.Euler(0, 0, -90);
        }
        
    }
}
