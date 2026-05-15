using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AppManager : MonoBehaviour
{
    [Header("AR References")]
    [SerializeField] private ARSession arSession;
    [SerializeField] private UIStateManager uIStateManager;

    public void QuitApplication()
    {
        Application.Quit();

        Debug.Log("App has been quit!");
    }

    public void ResetTracking()
    {
        if (arSession != null)
        {
            arSession.Reset();

            if (uIStateManager != null)
            {
                uIStateManager.SetState(AppState.Scanning);
            }

            Debug.Log("AR Session has been reset!");
        }
    }
}