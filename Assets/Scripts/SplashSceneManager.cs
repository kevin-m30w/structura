using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneManager : MonoBehaviour
{
    public void LoadToApp()
    {
        SceneManager.LoadScene("01_AR_Scanner");
    }
}
