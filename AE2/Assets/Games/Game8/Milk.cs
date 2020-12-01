using UnityEngine;

public class Milk : MonoBehaviour
{
    private GameObject ObjectToMove;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 Pos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 DragPos = new Vector2(Pos.x, Pos.y);

                var Hit = Physics2D.OverlapPoint(DragPos);

                if (Hit)
                {
                    if (Hit.transform == transform)
                    {
                        ObjectToMove = gameObject;
                    }
                }

            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 Pos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 DragPos = new Vector2(Pos.x, Pos.y);

                ObjectToMove.transform.position = DragPos;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                ObjectToMove = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "bin")
        {
            SceneTranstition.Win();
        }
        
    }
}
