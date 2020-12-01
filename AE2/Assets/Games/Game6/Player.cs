using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    
    float HalfScreenWidthInWorldPoints;
    Rigidbody2D rigid;

    void Start()
    {
        float HalfPlayerWidth = transform.localScale.x / 2f;

        HalfScreenWidthInWorldPoints = Camera.main.aspect * Camera.main.orthographicSize + HalfPlayerWidth;

        Input.gyro.enabled = true;
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(-Input.gyro.rotationRateUnbiased.y * Speed, 0f);

        if(transform.position.x < -HalfScreenWidthInWorldPoints)
            transform.position = new Vector2(HalfScreenWidthInWorldPoints, transform.position.y);

        if (transform.position.x > HalfScreenWidthInWorldPoints)
            transform.position = new Vector2(-HalfScreenWidthInWorldPoints, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneTranstition.Lose();
    }
}
