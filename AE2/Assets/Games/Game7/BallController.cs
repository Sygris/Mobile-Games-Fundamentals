using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float Power = 10f;
    public float MaxDrag = 5f;

    private Rigidbody2D rb;
    private LineRenderer lr;

    private Vector3 DragstartPosition;
    private Touch touch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                Dragstart();

            if (touch.phase == TouchPhase.Moved)
                Dragging();

            if (touch.phase == TouchPhase.Ended)
                DragRelease();
        }
    }

    void Dragstart()
    {
        DragstartPosition = Camera.main.ScreenToWorldPoint(touch.position);
        DragstartPosition.z = 0f;

        lr.positionCount = 1;
        lr.SetPosition(0, DragstartPosition);
    }

    void Dragging()
    {
        Vector3 DraggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        DraggingPos.z = 0f;

        lr.positionCount = 2;
        lr.SetPosition(1, DraggingPos);
    }

    void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 DragReleasepos = Camera.main.ScreenToWorldPoint(touch.position);
        DragReleasepos.z = 0;

        Vector3 Force = DragstartPosition - DragReleasepos;
        Vector3 ClampedForce = Vector3.ClampMagnitude(Force, MaxDrag) * Power;

        rb.AddForce(ClampedForce, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("LOST");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // REMOVE USING
    }
}
