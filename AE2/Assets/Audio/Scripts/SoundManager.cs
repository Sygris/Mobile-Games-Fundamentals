using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public AudioMixerSnapshot Normal;
    public AudioMixerSnapshot Fast;
    public AudioMixerSnapshot Faster;

    private int CurrentLevel;

    void Awake()
    {
        int SoundManagers = FindObjectsOfType<SoundManager>().Length;

        if (SoundManagers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        CurrentLevel = SceneTranstition.GetCurrentLevel();

        switch (CurrentLevel)
        {
            case 5:
                Fast.TransitionTo(0.5f);
                break;
            case 10:
                Faster.TransitionTo(0.5f);
                break;
            default:
                break;
        }
    }
}
