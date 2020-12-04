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
        else
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 2:
                    SceneTranstition.Win();
                    break;
                case 6:
                    SceneTranstition.Win();
                    break;
                case 9:
                    SceneTranstition.Win();
                    break;
                case 10:
                    break;
                default:
                    SceneTranstition.Lose();
                    break;
            }
        }
    }

    public float GetTimeLeft() { return TimeLeft; }
}
