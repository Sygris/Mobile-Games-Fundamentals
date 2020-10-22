using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletManager
{
    public static List<GameObject> ListOfBlueBullets = new List<GameObject>();
    public static List<GameObject> ListOfRedBullets = new List<GameObject>();
    public static int ListOfDestroyedBullets = 0;

    public static void Print()
    {
        Debug.Log("RED bullets: " + ListOfRedBullets.Count);
        Debug.Log("BLUE bullets: " + ListOfBlueBullets.Count);
        Debug.Log("DESTROYED bullets: " + ListOfDestroyedBullets);
    }

    public static void AddGravity()
    {
        foreach (var BlueBullet in ListOfBlueBullets)
        {
            BlueBullet.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
