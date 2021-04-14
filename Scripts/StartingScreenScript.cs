using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreenScript : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void GoBackButton()
    {
        optionsMenu.SetActive(false);
    }
}
