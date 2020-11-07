using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> Weapons = new List<GameObject>();
    public GameObject Arrow;
    public Transform ShootingPoint;
    public Text CastingUI;

    private Animator animator;
    private int CurrentWeapon;

    void Start()
    {
        animator = GetComponent<Animator>();

        SetAllFalse();

        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].name == "Sword")
            {
                Weapons[i].SetActive(true);
                CurrentWeapon = i;
            }
        }
    }

    void Update()
    {
        if (!GetComponent<Player>().IsInputLocked)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetAllFalse();
                Weapons[0].SetActive(true);
                CurrentWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetAllFalse();
                Weapons[1].SetActive(true);
                CurrentWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetAllFalse();
                Weapons[2].SetActive(true);
                CurrentWeapon = 2;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Attack();
            }
        }
    }

    void SetAllFalse()
    {
        foreach (var Weapon in Weapons)
        {
            Weapon.SetActive(false);
        }
    }

    void Attack()
    {

        switch (Weapons[CurrentWeapon].name)
        {
            case "Sword":
                animator.SetTrigger("Attacking");
                break;
            case "Bow":
                animator.SetTrigger("Bow");
                break;
            case "Staff":
                animator.SetTrigger("Casting");
                break;
            default:
                break;
        }

    }

    private IEnumerator PrintSpellUI(float delay)
    {
        CastingUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        CastingUI.gameObject.SetActive(false);
    }

    void SpawnArrow()
    {
        Instantiate(Arrow, ShootingPoint.position, Quaternion.identity);
    }
}
