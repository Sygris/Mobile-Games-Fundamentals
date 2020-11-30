using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPlayer : MonoBehaviour
{
    public float Speed = 1f;
    public float Fallingspeed = 5f;

    private bool IsHolding = false;
    private bool IsFalling = false;

    private Rigidbody2D Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
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
                        IsHolding = true;
                }

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                IsHolding = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!IsHolding)
        {
            Rigid.velocity = new Vector2(Speed, 0);
        }

        if (IsFalling)
        {
            Rigid.velocity = new Vector2(Speed, -5);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Square")
        {
            IsFalling = true;
        }
    }
}
