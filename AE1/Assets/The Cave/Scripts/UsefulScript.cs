using UnityEngine;
using UnityEngine.SceneManagement;

public class UsefulScript : MonoBehaviour
{
    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
