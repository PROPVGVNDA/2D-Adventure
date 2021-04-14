using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject gameLostScreen;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject[] menuList;

    private void Awake()
    {
        playerController.gameLost += GameLost;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();
    }

    private void GameLost()
    {
        ActivateMenu(0, false);
        ActivateMenu(1, true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        ActivateMenu(3, true);
    }

    public void PauseGame()
    {
        if (gameLostScreen.activeInHierarchy || optionsMenu.activeInHierarchy || pauseMenu.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (gameLostScreen.activeInHierarchy && optionsMenu.activeInHierarchy)
        {
            ActivateMenu(3, false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        if (optionsMenu.activeInHierarchy)
        {
            ActivateMenu(3, false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        if (pauseMenu.activeInHierarchy)
        {
            ActivateMenu(2, false, true);
            return;
        }
        if (!pauseMenu.activeInHierarchy && !gameLostScreen.activeInHierarchy)
        {
            ActivateMenu(2, true, false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
    }

    public void ResumeGame()
    {
        ActivateMenu(2, false, true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ActivateMenu(int menuIndex, bool state)
    {
        menuList[menuIndex].SetActive(state);
    }

    private void ActivateMenu(int menuIndex, bool state, bool playerState)
    {
        menuList[menuIndex].SetActive(state);
        player.SetActive(playerState);
    }
}
