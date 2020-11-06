using UnityEngine;

public class ArrowAnim : MonoBehaviour
{
    public float Arrowspeed;

    private Player Player;
    private Rigidbody2D MyRig;

    void Start()
    {
        Player = FindObjectOfType<Player>();
        MyRig = GetComponent<Rigidbody2D>();

        if (!Player.IsPlayerFacingRight)
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void FixedUpdate()
    {
        if (Player.IsPlayerFacingRight)
        {
            MyRig.velocity += new Vector2(Arrowspeed, MyRig.velocity.y);
        }
        else
        {
            MyRig.velocity += new Vector2(-Arrowspeed, MyRig.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
