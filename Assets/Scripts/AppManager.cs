using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AppManager : MonoBehaviour
{
    [Header("AR References")]
    [SerializeField] private ARSession arSession;
    [SerializeField] private UIStateManager uIStateManager;

    [Header("Other References")]
    [SerializeField] private GameObject quitModal;
    [SerializeField] private Animator quitModalAnimator;

    public void OpenQuitModal()
    {
        Debug.Log("Open Quit Modal");
        quitModal.SetActive(true);
        quitModalAnimator.SetBool("IsOpen", true);
    }

    public void CloseQuitModal()
    {
        quitModal.SetActive(false);
        quitModalAnimator.SetBool("IsOpen", false);
    }

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