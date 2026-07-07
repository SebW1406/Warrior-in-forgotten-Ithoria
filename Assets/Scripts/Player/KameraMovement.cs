using UnityEngine;

public class KameraMovement : MonoBehaviour
{
    private Transform camPlayer;
    [SerializeField] private float smoothSpeed = 5f;
    private Vector3 offset = new Vector3(0, 0, -10);

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsByType<Camera>().Length > 1)
        {
            DestroyImmediate(gameObject);
            return;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 zielPosition = camPlayer.position + offset;
        transform.position = Vector3.Lerp(transform.position, zielPosition, smoothSpeed * Time.deltaTime);
    }

    public void Player(Transform player)
    {
        camPlayer = player;
    }
}
