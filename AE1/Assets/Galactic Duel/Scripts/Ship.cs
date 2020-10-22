using System.Collections;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform Target;
    public string VerticalInput;
    public string HorizontalInput;
    public float Speed;
    public bool IsFacingRight;

    public int Health;
    public int BlinkInterval;

    private Vector2 ScreenBoundaries;
    private float Width;
    private float Height;

    private void Start()
    {
        ScreenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Width = GetComponent<SpriteRenderer>().size.x / 2;
        Height = GetComponent<SpriteRenderer>().size.y / 2;
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, ScreenBoundaries.x * -1 + Width, ScreenBoundaries.x - Width);
        viewPos.y = Mathf.Clamp(viewPos.y, ScreenBoundaries.y * -1 + Height, ScreenBoundaries.y - Height);
        transform.position = viewPos;
    }

    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw(HorizontalInput), Input.GetAxisRaw(VerticalInput), 0).normalized;

        transform.Translate(movement * Time.deltaTime * Speed);

        float TargetCurrentX = Target.position.x;
        float ShipCurrentX = transform.position.x;


        if (TargetCurrentX > ShipCurrentX && !IsFacingRight)
        {
            Flip();
        }
        else if (TargetCurrentX < ShipCurrentX && IsFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;

        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    public void TakeDamage()
    {
        if (Health > 0)
        {
            --Health;
            StartCoroutine(Blink(BlinkInterval));
        }
        
        if(Health <= 0)
        {
            GameManager.GameOver();
        }
    }

    IEnumerator Blink(float Interval)
    {
        float endTime = Time.time + Interval;
        while (Time.time < endTime)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }


}
