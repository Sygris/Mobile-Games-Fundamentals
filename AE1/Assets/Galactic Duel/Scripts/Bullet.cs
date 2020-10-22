using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private string Bulletcolor;

    void Start()
    {
        string ParentName = transform.parent.name;
        gameObject.name = ParentName + " Bullet";

        if (!transform.parent.GetComponent<Ship>().IsFacingRight)
            Speed *= -1;

        switch (ParentName.ToLower())
        {
            case "red":
                BulletManager.ListOfRedBullets.Add(gameObject);
                Bulletcolor = "red";
                break;
            case "blue":
                BulletManager.ListOfBlueBullets.Add(gameObject);
                Bulletcolor = "blue";
                break;
            default:
                break;
        }

        transform.SetParent(null);
    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Color collisionColor = collision.GetComponent<SpriteRenderer>().color;
        Color bulletColor = gameObject.GetComponent<SpriteRenderer>().color;

        if (collisionColor != bulletColor)
        {
            collision.GetComponent<Ship>().TakeDamage();

            RemoveBulletFromList();

            gameObject.SetActive(false);

        }

    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
        {
            BulletManager.ListOfDestroyedBullets++;

            RemoveBulletFromList();

            Destroy(gameObject);
        }

    }

    private void RemoveBulletFromList()
    {
        if (Bulletcolor == "red")
        {
            BulletManager.ListOfRedBullets.Remove(gameObject);
        }

        if (Bulletcolor == "blue")
        {
            BulletManager.ListOfBlueBullets.Remove(gameObject);
        }

    }

}
