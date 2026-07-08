using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadTitelScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadOptionScreen()
    {
        SceneManager.LoadScene("OptionsMainScreen");
    }
    public void doExitGame()
    {
        Application.Quit();
    }

}
