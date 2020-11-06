using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = transform.Find("Sword").GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    void Update()
    {
    }

    public void AttackSword(string message)
    {
        if (message.Equals("start"))
            boxCollider.enabled = true;

        if (message.Equals("End"))
            boxCollider.enabled = false;
    }
}
