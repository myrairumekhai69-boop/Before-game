using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { MainMenu, Playing, Cutscene, Paused }
    public GameState CurrentState = GameState.MainMenu;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        Time.timeScale = (newState == GameState.Paused) ? 0 : 1;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
