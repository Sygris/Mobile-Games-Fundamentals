using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeInSeconds = 71f;

    private bool IsTimeLeft = true;
    private Text TimerText;

    private bool Display;

    void Start()
    {
        TimerText = GetComponent<Text>();
    }

    void Update()
    {
        if (IsTimeLeft)
        {
            if (TimeInSeconds > 0)
            {
                TimeInSeconds -= Time.deltaTime;

                DisplayTimeLeft(TimeInSeconds);
                
                if (TimeInSeconds <= 30)
                    TimerText.color = Color.red;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                TimeInSeconds = 0;
                IsTimeLeft = false;
            }
        }
    }

    private void DisplayTimeLeft(float TimeLeft)
    {
        TimeLeft += 1;

        float minutes = Mathf.FloorToInt(TimeLeft / 60);
        float seconds = Mathf.FloorToInt(TimeLeft % 60);

        TimerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }
}
