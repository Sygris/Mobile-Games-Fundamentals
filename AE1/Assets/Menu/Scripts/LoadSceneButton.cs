using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadScene()
    {
        string sceneName = gameObject.GetComponentInChildren<Text>().text;

        SceneManager.LoadScene(sceneName);
    }

}

