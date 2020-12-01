using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector3 accelerationDir;
    private List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();

    public float Delay;

    void Start()
    {
        for (int child = 0; child < transform.childCount; child++)
        {
            rigidbody2Ds.Add(transform.GetChild(child).GetComponent<Rigidbody2D>());
        }
    }

    void Update()
    {
        accelerationDir = Input.acceleration;

        if (accelerationDir.sqrMagnitude >= 5f)
        {
            StartCoroutine(DropCoins(Delay));
        }
    }

    IEnumerator DropCoins(float delay)
    {
        foreach (var coin in rigidbody2Ds)
        {
            coin.isKinematic = false;
        }

        yield return new WaitForSeconds(delay);
        
        SceneTranstition.Win();

    }
}
