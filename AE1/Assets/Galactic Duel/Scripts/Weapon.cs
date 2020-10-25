using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string ShootButton;
    public GameObject BulletPrefab;
    public float Interval;
    public float ArcAttackPressTime;
    public int ArcLength;

    private float CurrentTime;
    private float PressTime;

    void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime > Interval)
        {
            if (Input.GetButtonDown(ShootButton))
            {
                Shoot();
                CurrentTime = 0;
            }
        }
    }

    void Shoot()
    {
        GameObject go = Instantiate(BulletPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void ShootArc()
    {
        int HalfArcLength = ArcLength / 2;

        List<GameObject> ListOfBulletsArc = new List<GameObject>
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0f, 0f, HalfArcLength)),
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0f, 0f, 0f)),
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(0f, 0f, -HalfArcLength))
        };

        foreach (var item in ListOfBulletsArc)
        {
            item.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
        }

        ListOfBulletsArc.Clear();
    }
}
