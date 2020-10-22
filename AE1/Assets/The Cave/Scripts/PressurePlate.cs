using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject ArrowPrefab;
    public Transform Origin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(ArrowPrefab, Origin.position, Origin.rotation);
        }
    }
}
