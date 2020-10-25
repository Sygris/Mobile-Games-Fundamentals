using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    private ParticleSystem Ps;
    private Player Player;

    public float Interval;
    private float CurrentTimer;

    public float FireTicks;
    public int FireDamageMin;
    public int FireDamageMax;
    private float CurrentFireTicks;
    private bool IsPlayerOnFire = false;

    private bool IsPlayerInTheRoom = false;
    private int DOT_DEBUFF;

    public float IncrementDOTDEBUFFTime;
    private float TimePlayerIsInsideRoom;

    void Start()
    {
        Ps = GetComponent<ParticleSystem>();
        CurrentFireTicks = FireTicks;
    }

    void Update()
    {
        PlayerInsideTheRoom();

        if (DOT_DEBUFF == 10)
            IsPlayerOnFire = true;

        BurnPlayer();
    }

    int Damage()
    {
        return Random.Range(FireDamageMin, FireDamageMax);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ps.Play();
            Player = collision.GetComponent<Player>();
            Debug.Log("Warning: Fire");

            IsPlayerInTheRoom = !IsPlayerInTheRoom;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ps.Stop();
            IsPlayerInTheRoom = !IsPlayerInTheRoom;
            DOT_DEBUFF = 0;
        }
    }

    void PlayerInsideTheRoom()
    {
        if (IsPlayerInTheRoom)
        {
            TimePlayerIsInsideRoom += Time.deltaTime;

            if (TimePlayerIsInsideRoom > IncrementDOTDEBUFFTime)
            {
                DOT_DEBUFF++;
                TimePlayerIsInsideRoom = 0;
            }
        }
    }

    void BurnPlayer()
    {
        if (IsPlayerOnFire)
        {
            DOT_DEBUFF = 0;
            Debug.Log("ON FIRE!!");

            CurrentTimer += Time.deltaTime;

            if (CurrentTimer > Interval)
            {
                CurrentFireTicks--;
                Player.TakeDamage(Damage());

                CurrentTimer = 0;

                IsPlayerOnFire = !(CurrentFireTicks == 0);
            }
        }
    }
}
