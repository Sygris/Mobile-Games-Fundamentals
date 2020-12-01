using UnityEngine;

public class Lift : MonoBehaviour
{
    private Vector3 FirstTouchPos;
    private Vector3 LastTouchPos;

    public int ScreenPercentageForSwipe;

    private float DragDistance;
    public float MoveAmount;

    private Rigidbody2D Rig;

    private void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        DragDistance = Screen.height * ScreenPercentageForSwipe / 100;
    }

    private void FixedUpdate()
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

                if ( Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > DragDistance || Mathf.Abs(LastTouchPos.y - FirstTouchPos.y) > DragDistance)
                {
                    // If true, it means that it's a vertical swipe
                    if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) < Mathf.Abs(LastTouchPos.y - FirstTouchPos.y))
                    {
                        // Up Swipe
                        if (LastTouchPos.y > FirstTouchPos.y)
                        {
                            Rig.velocity = new Vector2(0, MoveAmount);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneTranstition.Win();
    }
}
