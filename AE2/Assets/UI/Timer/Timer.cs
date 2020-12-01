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
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneTranstition.Win();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneTranstition.Win();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            SceneTranstition.Win();
        }
        else
        {
            SceneTranstition.Lose();
        }
    }
}
