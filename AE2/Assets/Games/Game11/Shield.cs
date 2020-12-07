using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject TheShield;

    public GameObject ShieldInfo;

    public float ShieldActiveTime;

    public float SecondsBetweenShieldRespawn = 1f;
    float NextShieldTime = 3f;

    private bool CanUseShield = false;

    void Start()
    {
    }

    void Update()
    {
        if (!CanUseShield)
        {
            if (Time.time > NextShieldTime)
            {
                NextShieldTime = Time.time + SecondsBetweenShieldRespawn;

                CanUseShield = true;
            }
        }
        else
        {
            ShieldInfo.SetActive(true);

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 TouchPosition = new Vector2(Position.x, Position.y);

                    var Hit = Physics2D.OverlapPoint(TouchPosition);

                    if (Hit)
                    {
                        if (Hit.transform == transform)
                        {
                            StartCoroutine(ShieldDuration());

                            CanUseShield = false;

                            ShieldInfo.SetActive(false);
                        }
                    }
                }

            }

        }
    }

    IEnumerator ShieldDuration()
    {
        TheShield.SetActive(true);

        yield return new WaitForSeconds(ShieldActiveTime);

        TheShield.SetActive(false);
    }
}
