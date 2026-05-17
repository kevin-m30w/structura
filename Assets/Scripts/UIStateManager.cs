using UnityEngine;

public enum AppState { Scanning, BuildingPlaced }

public class UIStateManager : MonoBehaviour
{
    [Header("UI State Panels")]
    [SerializeField] private GameObject scanningPanel;
    [SerializeField] private GameObject filteringPanel;

    [Header("UI State Animators")]
    [SerializeField] private Animator scanningAnimator;
    [SerializeField] private Animator filteringAnimator;

    private AppState currentState;

    void Start()
    {
        SetState(AppState.Scanning);
    }

    public void SetState(AppState newState)
    {
        currentState = newState;

        scanningPanel.SetActive(currentState == AppState.Scanning);
        filteringPanel.SetActive(currentState == AppState.BuildingPlaced);

        if (scanningAnimator != null)
        {
            scanningAnimator.SetBool("IsOpen", currentState == AppState.Scanning);
        }

        if (filteringAnimator != null)
        {
            filteringAnimator.SetBool("IsOpen", currentState == AppState.BuildingPlaced);
        }
        //if (currentState == AppState.BuildingPlaced)
        //{
        //    ShowAll();

        //    if (floorDropdown != null) floorDropdown.value = 0;
        //}
    }
}