using System.Collections;
using UnityEngine;
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

    public static void Lose()
    {
        Lives--;

        if (Lives > 0)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {
            Lives = MaxLives;
            CurrentLevel = 1;

            SceneManager.LoadScene("Menu");
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

    public static int GetCurrentLevel()
    {
        return CurrentLevel;
    }
}
