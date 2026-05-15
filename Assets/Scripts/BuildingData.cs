using UnityEngine;

public class BuildingData : MonoBehaviour
{
    [Header("Data")]
    public GameObject[] floors;
    public GameObject[] walls;
    public GameObject roof;

    void Start()
    {
        if (FilteringUI.Instance != null)
        {
            FilteringUI.Instance.RegisterBuilding(this);
        }
    }
}
