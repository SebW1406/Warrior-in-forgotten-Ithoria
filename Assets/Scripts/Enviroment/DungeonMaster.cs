using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    [Header("Alle Räume")]
    [SerializeField] GameObject Room_1;
    [SerializeField] GameObject Room_2;


    public static string activeRoom = "Room_1";

    public static void SetActiveRoom(string room)
    {
        activeRoom = room;
    }
    void Update()
    {
        Room_1.SetActive(DungeonMaster.activeRoom == "Room_1");
        Room_2.SetActive(DungeonMaster.activeRoom == "Room_2");
    }

}
