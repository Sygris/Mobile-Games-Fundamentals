using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float Speed;
    public Transform Red;
    public Transform Blue;

    private bool GoTORedShip = false;


    void Update()
    {

        Move();
    }

    void Move()
    {
        Vector3 RedPos = new Vector3(Red.position.x, 0, 0);
        
        if (transform.parent == null)
        {
            Vector3 BluePos = new Vector3(Blue.position.x, 0, 0);

            if (GoTORedShip)
            {
                transform.position = Vector3.MoveTowards(transform.position, RedPos, Speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, BluePos, Speed * Time.deltaTime);
            }

            CheckDirection(RedPos, BluePos);
        }
        else 
        {
            transform.position = RedPos;
        }
    }

    void CheckDirection(Vector3 RedPos, Vector3 BluePos)
    {
        if ((transform.position == RedPos) && (GoTORedShip))
        {
            GoTORedShip = false;
        }
        else if ((transform.position == BluePos) && (!GoTORedShip))
        {
            GoTORedShip = true;
        }
    }
}

