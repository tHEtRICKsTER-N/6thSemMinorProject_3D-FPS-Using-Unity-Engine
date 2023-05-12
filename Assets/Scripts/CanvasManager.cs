using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _instructionsPanel;
    [SerializeField] private GameObject _pausePanel;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        if (_instructionsPanel.activeInHierarchy)
        {
            _instructionsPanel.SetActive(false);
        }
        else
        {
            _instructionsPanel.SetActive(true);
        }
    }

}
