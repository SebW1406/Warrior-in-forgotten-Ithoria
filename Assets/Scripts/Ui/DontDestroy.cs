using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsByType<Canvas>().Length > 1)
        {
            DestroyImmediate(gameObject);
            return;
        }

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }


}
