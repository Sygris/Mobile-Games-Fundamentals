using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePlayer : MonoBehaviour
{
    const int RIGHT = 0;
    const int LEFT = 1;

    [Header("Swipe Settings")]
    public int ScreenPercentageForSwipe;

    private Vector3 FirstTouchPos;
    private Vector3 LastTouchPos;

    private float DragDistance;

    [Header("Position Settings")]
    public int StartLane;
    public List<Transform> LaneTransforms;

    private int CurrentLane;

    void Start()
    {
        DragDistance = Screen.width * ScreenPercentageForSwipe / 100;

        CurrentLane = StartLane;
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
                        if (LastTouchPos.x < FirstTouchPos.x)
                        {
                            ChangeLane(LEFT);
                        }
                        else
                        {
                            ChangeLane(RIGHT);
                        }
                    }
                }
            }
        }
    }

    private void ChangeLane(int direction)
    {
        int TempLane = CurrentLane;

        if (direction == RIGHT)
        {
            TempLane++;

            if (TempLane < LaneTransforms.Count)
            {
                transform.position = LaneTransforms[TempLane].position;
                CurrentLane = TempLane;
            }
        }
        else
        {
            TempLane--;

            if (TempLane >= 0)
            {
                transform.position = LaneTransforms[TempLane].position;
                CurrentLane = TempLane;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!transform.GetChild(0).gameObject.activeInHierarchy)
            SceneTranstition.Lose();
        else
            Destroy(collision.gameObject);
    }
}
