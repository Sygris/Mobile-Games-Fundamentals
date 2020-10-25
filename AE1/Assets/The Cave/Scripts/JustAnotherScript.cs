using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustAnotherScript : MonoBehaviour
{

    private GameObject TheDungeonDoor;

    public void OpenDungeonDoor()
    {
        TheDungeonDoor = GameObject.Find("The Freaking Dungeon Door");
        StartCoroutine(OpenItThen());
    }

    public IEnumerator OpenItThen()
    {
        yield return new WaitForSeconds(1);
        TheDungeonDoor.gameObject.SetActive(false);

    }
}
