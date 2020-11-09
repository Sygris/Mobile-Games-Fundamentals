using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeInSeconds = 71f;

    public AudioMixerSnapshot Ordinary;
    public AudioMixerSnapshot Panic;

    private bool IsTimeLeft = true;
    private Text TimerText;

    private float DisplayDoubleColonTimer = 1f; //Starts as 1 so it can print the first second
    private float DoubleColonInterval = 1f;
    private bool DisplayDoubleColon;

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
                {
                    TimerText.color = Color.red;
                    Panic.TransitionTo(1);
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Ordinary.TransitionTo(1);
                TimeInSeconds = 0;
                IsTimeLeft = false;
            }
        }
    }

    private void DisplayTimeLeft(float TimeLeft)
    {
        DisplayDoubleColonTimer += Time.deltaTime;

        if (DisplayDoubleColonTimer > DoubleColonInterval)
        {
            TimeLeft += 1;

            float minutes = Mathf.FloorToInt(TimeLeft / 60);
            float seconds = Mathf.FloorToInt(TimeLeft % 60);

            DisplayDoubleColon = !DisplayDoubleColon;

            if (DisplayDoubleColon)
                TimerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
            else
                TimerText.text = string.Format("{00:00} {01:00}", minutes, seconds);
            
            DisplayDoubleColonTimer = 0;
        }
    }
}
