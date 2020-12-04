using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButton : MonoBehaviour
{
    bool IsHolding = false;

    Timer timer;

    public Sprite buttonDown;
    public Sprite buttonUp;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 HoldPos = new Vector2(Pos.x, Pos.y);

                var Hit = Physics2D.OverlapPoint(HoldPos);
                if (Hit)
                {
                    if (Hit.transform == transform)
                    {
                        IsHolding = true;
                        gameObject.GetComponent<SpriteRenderer>().sprite = buttonDown;
                    }
                }

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                IsHolding = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = buttonUp;
            }
        }

        if (IsHolding && (timer.GetTimeLeft() <= 0))
        {
            SceneTranstition.Win();
        }

        if (!IsHolding && (0 >= timer.GetTimeLeft()))
        {
            SceneTranstition.Lose();
        }
    }
}
