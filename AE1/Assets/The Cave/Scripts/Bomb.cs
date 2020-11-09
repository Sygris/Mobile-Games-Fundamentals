using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float BombRadius;
    public float BombForce;
    public float BombDefuseTime;
    public LayerMask EffectLayer;
    public float ShakeForce;

    private bool IsPlayerInTheRoom = false;
    private float CurrentTime;

    void Update()
    {

        if (IsPlayerInsideRadius())
        {
            CurrentTime += Time.deltaTime;

            transform.position = transform.position + Random.insideUnitSphere * (Time.deltaTime * ShakeForce);

            if (CurrentTime >= BombDefuseTime)
            {
                Explode();
                CurrentTime = 0;
            }
        }
    }

    void Explode()
    {
        Collider2D[] Colliders = Physics2D.OverlapCircleAll(transform.position, BombRadius, EffectLayer);

        foreach (var col in Colliders)
        {
            Vector2 Direction = col.transform.position - transform.position;

            if (col.CompareTag("Player"))
            {
                FindObjectOfType<UsefulScript>().KillPlayer();
            }

            col.GetComponent<Rigidbody2D>().velocity = Direction * BombForce;

        }

        Destroy(gameObject);

        FindObjectOfType<MenuManager>().ShowMenu();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, BombRadius);
    }

    bool IsPlayerInsideRadius()
    {
        Vector2 Distance = transform.position - FindObjectOfType<Goblin>().transform.position;

        if (Distance.x <= BombRadius)
            IsPlayerInTheRoom = true;

        return IsPlayerInTheRoom;
    }
}
