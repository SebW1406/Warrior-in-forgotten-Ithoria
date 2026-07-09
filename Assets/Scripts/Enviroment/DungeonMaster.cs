using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    [Header("Alle Räume")]
    [SerializeField] GameObject Room_1;
    [SerializeField] GameObject Room_2;
    [SerializeField] GameObject Room_3;
    [SerializeField] GameObject Room_4;


    public static string activeRoom = "Room_1";

    public static void SetActiveRoom(string room)
    {
        activeRoom = room;
    }
    void Update()
    {
        Room_1.SetActive(DungeonMaster.activeRoom == "Room_1");
        Room_2.SetActive(DungeonMaster.activeRoom == "Room_2");
        Room_3.SetActive(DungeonMaster.activeRoom == "Room_3");
        Room_4.SetActive(DungeonMaster.activeRoom == "Room_4");

    }

}
