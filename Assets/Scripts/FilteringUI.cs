using UnityEngine;
using UnityEngine.UI;

public class FilteringUI : MonoBehaviour
{
    public static FilteringUI Instance;

    [Header("Settings")]
    private GameObject[] floors;
    private GameObject[] walls;
    private GameObject roof;

    [Header("UI References")]
    [SerializeField] private Toggle wallToggle;

    private bool isShowingAll = false;
    private int currentFloorIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterBuilding(BuildingData data)
    {
        floors = data.floors;
        walls = data.walls;
        roof = data.roof;

        Debug.Log("Building Registered successfully!");
        ShowAll();
    }

    public void OnDropdownChanges(int index)
    {
        if (index == 0) ShowAll();
        else SetFloor(index - 1);
    }

    public void ToggleWalls(bool isOn)
    {
        UpdateVisuals();
    }

    private void SetFloor(int index)
    {
        isShowingAll = false;
        currentFloorIndex = index;

        SetToggleInteractable(true);
        UpdateVisuals();
        roof.SetActive(false);
    }

    public void ShowAll()
    {
        isShowingAll = true;
        SetToggleInteractable(false);
        UpdateVisuals();
        roof.SetActive(true);
    }

    private void UpdateVisuals()
    {
        // SAFETY CHECK: If no building has spawned yet, stop right here.
        if (floors == null || floors.Length == 0) return;

        bool wallsEnabledByToggle = wallToggle != null && wallToggle.isOn;

        for (int i = 0; i < floors.Length; i++)
        {
            if (isShowingAll)
            {
                floors[i].SetActive(true);
                walls[i].SetActive(true);
            }
            else
            {
                if (i < currentFloorIndex)
                {
                    // Floors BELOW the selected one: 
                    // Always show the floor and the walls (structural support)
                    floors[i].SetActive(true);
                    walls[i].SetActive(true);
                }
                else if (i == currentFloorIndex)
                {
                    // The SELECTED floor:
                    // Show the floor, but let the toggle control the walls
                    floors[i].SetActive(true);
                    walls[i].SetActive(wallsEnabledByToggle);
                }
                else if (i > currentFloorIndex)
                {
                    // Floors ABOVE the selected one:
                    // Hide everything
                    floors[i].SetActive(false);
                    walls[i].SetActive(false);
                }
            }
        }
    }

    private void SetToggleInteractable(bool state)
    {
        if (wallToggle != null)
        {
            wallToggle.interactable = state;
        }
    }
}