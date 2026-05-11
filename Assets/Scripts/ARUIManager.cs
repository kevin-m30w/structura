using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems; // Required for checking the TrackingState

public class ARUIManager : MonoBehaviour
{
    [Header("AR Components")]
    public ARTrackedImageManager imageManager;

    [Header("UI Elements")]
    public GameObject scanPromptUI;

    // OnEnable is called when the script is turned on
    void OnEnable()
    {
        // Tell the image manager: "Whenever your tracking changes, run my function!"
        imageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    // OnDisable is called when the script is turned off (cleans up memory)
    void OnDisable()
    {
        imageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    // This function runs automatically whenever a target is found, updated, or lost
    void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        bool isCurrentlyTracking = false;

        // Loop through all images the AR camera currently knows about
        foreach (var trackedImage in imageManager.trackables)
        {
            // If even one image is actively being tracked, set our boolean to true
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                isCurrentlyTracking = true;
                break; // Stop looping, we found what we need
            }
        }

        // If we ARE tracking, hide the UI (SetActive to false).
        // If we are NOT tracking, show the UI (SetActive to true).
        scanPromptUI.SetActive(!isCurrentlyTracking);
    }
}
