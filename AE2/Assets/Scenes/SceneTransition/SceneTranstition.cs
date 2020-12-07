using UnityEngine.SceneManagement;

public static class SceneTranstition
{
    const int MaxLives = 5;
    public static int Lives = MaxLives;
    private static int CurrentLevel = 1;

    public static void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public static void WonGame()
    {
        SceneManager.LoadScene("WonGame");
    }

    public static void Lose()
    {
        Lives--;

        if (Lives > 0)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {
            RestartGame();
        }
    }

    public static void NextLevel()
    {
        CurrentLevel++;

        SceneManager.LoadScene(CurrentLevel);
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    public static void RestartGame()
    {
        CurrentLevel = 1;
        Lives = MaxLives;

        SceneManager.LoadScene("Menu");
    }

    public static int GetCurrentLevel()
    {
        return CurrentLevel;
    }
}
