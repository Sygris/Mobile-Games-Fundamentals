using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector3 accelerationDir;
    private List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();

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
            foreach (var coin in rigidbody2Ds)
            {
                coin.isKinematic = false;
            }
        }
    }
}
