using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
