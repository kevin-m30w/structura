using UnityEngine;

public class FloorManager : MonoBehaviour
{
    // Ini buat nyambungin script ke objek lantai di Unity
    public GameObject Floor_1;
    public GameObject Floor_2;
    public GameObject Floor_3;
    public GameObject Floor_All;

    // Fungsi ini dipanggil pas tombol Floor 1 diklik
    public void ShowFloor1()
    {
        Floor_1.SetActive(true);  // Nyalain Lantai 1
        Floor_2.SetActive(false); // Matiin Lantai 2
        Floor_3.SetActive(false); // Matiin Lantai 3
        Floor_All.SetActive(false); // Matiin Lantai 4
    }

    // Fungsi ini dipanggil pas tombol Floor 2 diklik
    public void ShowFloor2()
    {
        Floor_1.SetActive(false);
        Floor_2.SetActive(true);
        Floor_3.SetActive(false);
        Floor_All.SetActive(false);
    }

    // Fungsi ini dipanggil pas tombol Floor 3 diklik
    public void ShowFloor3()
    {
        Floor_1.SetActive(false);
        Floor_2.SetActive(false);
        Floor_3.SetActive(true);
        Floor_All.SetActive(false);
    }

     // Fungsi ini dipanggil pas tombol Floor All diklik
    public void ShowFloorALL()
    {
        Floor_1.SetActive(false);
        Floor_2.SetActive(false);
        Floor_3.SetActive(false);
        Floor_All.SetActive(true);
    }
}