using UnityEngine;

public class Goblin : MonoBehaviour
{
    public float Speed;
    public int Health;
    public float RaycastLenght;

    private Rigidbody2D Rigidbody;
    private Vector2 movement;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        CheckForButton();
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = movement.normalized * Speed;
    }

    public void TakeDamage(int damage)
    {
        if (Health > 1)
        {
            Health -= damage;
        }
        else
        {
             FindObjectOfType<UsefulScript>().KillPlayer();
        }
    }

    void CheckForButton()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(RaycastLenght, 0, 0), Color.magenta);

        var Hits2D = Physics2D.RaycastAll(transform.position, Vector2.right, RaycastLenght);

        foreach (var item in Hits2D)
        {
            if (item.transform.name == "Button")
            {
                item.transform.GetComponent<JustAnotherScript>().OpenDungeonDoor();
                item.transform.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

}
