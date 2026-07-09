using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    [SerializeField] private string targetRoom;
    [SerializeField] private GameObject PlayerSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (DungeonMaster.activeRoom == "Room_1" && targetRoom == "Room_2")
            {
                collision.transform.position = PlayerSpawn.transform.position;
                DungeonMaster.SetActiveRoom("Room_2");
            }

            if (DungeonMaster.activeRoom == "Room_2" && targetRoom == "Room_1")
            {
                collision.transform.position = PlayerSpawn.transform.position;
                DungeonMaster.SetActiveRoom("Room_1");

            }

            if (DungeonMaster.activeRoom == "Room_2" && targetRoom == "Room_3")
            {
                collision.transform.position = PlayerSpawn.transform.position;
                DungeonMaster.SetActiveRoom("Room_3");

            }

            if (DungeonMaster.activeRoom == "Room_3" && targetRoom == "Room_2")
            {
                collision.transform.position = PlayerSpawn.transform.position;
                DungeonMaster.SetActiveRoom("Room_2");

            }

            if (DungeonMaster.activeRoom == "Room_3" && targetRoom == "Room_4")
            {
                collision.transform.position = PlayerSpawn.transform.position;
                DungeonMaster.SetActiveRoom("Room_4");

            }

            if (DungeonMaster.activeRoom == "Room_4" && targetRoom == "Room_3")
            {
                collision.transform.position = PlayerSpawn.transform.position;
                DungeonMaster.SetActiveRoom("Room_3");

            }

        }
    }
}
