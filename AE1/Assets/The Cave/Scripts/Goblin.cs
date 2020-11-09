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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<MenuManager>().ShowMenu();
        }

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
        var Hits2D = Physics2D.RaycastAll(transform.position, Vector2.right, RaycastLenght);

        foreach (var Hit in Hits2D)
        {
            if (Hit.transform.name == "Button")
            {
                Hit.transform.GetComponent<JustAnotherScript>().OpenDungeonDoor();
                Hit.transform.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

}