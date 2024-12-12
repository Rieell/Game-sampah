using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldProgressUI : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.gameObject.SetActive(false); // Awalnya tidak terlihat
    }

    public void ShowProgress()
    {
        slider.gameObject.SetActive(true); // Tampilkan saat digunakan
    }

    public void HideProgress()
    {
        slider.gameObject.SetActive(false); // Sembunyikan setelah selesai
    }

    public void UpdateProgress(float progress)
    {
        slider.value = progress; // Update nilai slider
    }
}
