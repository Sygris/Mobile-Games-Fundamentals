using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Animator Transition;

    public float TransitionDuration = 1f;

    void Start()
    {
        //Transition = GameObject.Find("Circle").GetComponent<Animator>();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        //Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionDuration);

        SceneManager.LoadScene(LevelIndex);
    }
}
