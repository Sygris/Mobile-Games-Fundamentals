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

        if (Index % 5.0f == 0.0f)
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
