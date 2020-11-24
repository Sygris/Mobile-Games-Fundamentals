using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinWheel : MonoBehaviour
{
    private Vector3 FirstTouchPos;
    private Vector3 LastTouchPos;

    public int ScreenPercentageForSwipe;

    private float DragDistance;

    public float RotationAmount;

    void Start()
    {
        DragDistance = Screen.width * ScreenPercentageForSwipe / 100;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                FirstTouchPos = touch.position;
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                LastTouchPos = touch.position;

                if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > DragDistance || Mathf.Abs(LastTouchPos.y - FirstTouchPos.y) > DragDistance)
                {
                    // If true, it means that it's a horizontal swipe
                    if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > Mathf.Abs(LastTouchPos.y - FirstTouchPos.y))
                    {
                        // Up Swipe
                        if (LastTouchPos.x > FirstTouchPos.x)
                        {
                            transform.Rotate(new Vector3(0, 0, RotationAmount));
                        }
                        else
                        {
                            transform.Rotate(new Vector3(0, 0, -RotationAmount));
                        }

                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
