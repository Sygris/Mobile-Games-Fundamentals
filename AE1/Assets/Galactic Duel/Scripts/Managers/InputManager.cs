using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public Star Star;
    public GameObject RedShip;

    private bool IsStarParented = false;

    private void Start()
    {
        Star = Star.GetComponent<Star>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            BulletManager.AddGravity();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            BulletManager.Print();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            IsStarParented = !IsStarParented;

            if (IsStarParented)
            {
                Star.transform.SetParent(RedShip.transform);
            }
            else
            {
                Star.transform.SetParent(null);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<MenuManager>().ShowMenu();
        }
    }
}
