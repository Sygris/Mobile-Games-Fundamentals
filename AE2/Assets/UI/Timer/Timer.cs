using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Image TimerBar;

    public float MaxTime = 6f;
    private float TimeLeft;

    void Start()
    {
        TimerBar = GetComponent<Image>();
        TimeLeft = MaxTime;

        float Index = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().buildIndex >= 5)
            MaxTime--;
    }

    void Update()
    {
        
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;

            TimerBar.fillAmount = TimeLeft / MaxTime;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
