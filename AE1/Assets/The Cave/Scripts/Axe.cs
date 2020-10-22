using UnityEngine;

public class Axe : MonoBehaviour
{
    public float RotationSpeed;
    private Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -RotationSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<UsefulScript>().KillPlayer();
        }
    }
}
