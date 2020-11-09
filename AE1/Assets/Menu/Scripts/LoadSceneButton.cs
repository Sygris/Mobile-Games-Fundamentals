using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadScene()
    {
        string sceneName = EventSystem.current.currentSelectedGameObject.name;

        SceneManager.LoadScene(sceneName);
    }

}

