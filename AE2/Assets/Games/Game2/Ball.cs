using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float JumpForce;

    private Rigidbody2D Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 NewPosition = new Vector2(Position.x, Position.y);

                var Hit = Physics2D.OverlapPoint(NewPosition);

                if (Hit)
                {
                    if (Hit.transform == transform)
                    {
                        Debug.Log("BU");
                        Rigid.AddForce(new Vector2(0, JumpForce));
                    }
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}