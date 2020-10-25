using UnityEngine;

public static class GameManager
{

    public static void GameOver()
    {
        string Winner = "";

        foreach (var ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            if (ship.GetComponent<Ship>().Health > 0)
            {
                Winner = ship.name;
            }

            ship.SetActive(false);
        }

        Debug.Log(Winner + " WON");

    }
}
