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

        if (SceneManager.GetActiveScene().buildIndex >= 5)
            MaxTime--;

        if (SceneManager.GetActiveScene().buildIndex == 11)
            MaxTime = 15f;

        TimeLeft = MaxTime;
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
                case 11:
                    SceneTranstition.WonGame();
                    break;
                default:
                    SceneTranstition.Lose();
                    break;
            }
        }
    }

    public float GetTimeLeft() { return TimeLeft; }
}
