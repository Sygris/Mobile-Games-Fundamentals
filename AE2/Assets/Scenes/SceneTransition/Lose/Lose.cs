using System.Collections;
using UnityEngine;

public class Lose : MonoBehaviour
{
    private void Start()
    {
        for (int Lives = 0; Lives < SceneTranstition.Lives; Lives++)
        {
            GameObject.Find("Panel").transform.GetChild(Lives).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(Tap());
            }
        }
    }

    IEnumerator Tap()
    {
        yield return new WaitForSeconds(0.5f);

        SceneTranstition.RestartLevel();
    }
}
