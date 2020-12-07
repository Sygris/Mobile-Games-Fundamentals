using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonGame : MonoBehaviour
{
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

        SceneTranstition.RestartGame();
    }
}
