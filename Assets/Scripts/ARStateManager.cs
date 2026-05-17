using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARStateController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager imageManager;
    [SerializeField] private UIStateManager uiStateManager;

    private void OnEnable()
    {
        imageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    private void OnDisable()
    {
        imageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            UpdateTrackingState(newImage);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            UpdateTrackingState(updatedImage);
        }
    }

    private void UpdateTrackingState(ARTrackedImage trackedImage)
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            uiStateManager.SetState(AppState.BuildingPlaced);
        }
        else
        {
            uiStateManager.SetState(AppState.Scanning);
        }
    }
}