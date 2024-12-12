using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottleInteraction : MonoBehaviour
{
    [SerializeField] private GameObject bottleUIPanel;
    [SerializeField] private TextMeshProUGUI bottleNameText;
    [SerializeField] private TextMeshProUGUI bottleDescriptionText;
    
    private void Start()
    {
        // Pastikan UI panel tidak aktif di awal
        if (bottleUIPanel != null)
        {
            bottleUIPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Gunakan raycast dari tengah layar
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Periksa apakah objek yang terdeteksi adalah botol
            Bottle bottleComponent = hit.transform.GetComponent<Bottle>();
            
            if (bottleComponent != null)
            {
                // Tampilkan UI botol
                ShowBottleUI(bottleComponent);
            }
            else
            {
                // Sembunyikan UI jika bukan botol
                HideBottleUI();
            }
        }
        else
        {
            // Sembunyikan UI jika tidak mendeteksi apapun
            HideBottleUI();
        }
    }

    void ShowBottleUI(Bottle bottle)
    {
        if (bottleUIPanel != null)
        {
            bottleUIPanel.SetActive(true);
            
            // Set informasi botol di UI
            if (bottleNameText != null)
                bottleNameText.text = bottle.bottleName;
            
            if (bottleDescriptionText != null)
                bottleDescriptionText.text = bottle.description;
        }
    }

    void HideBottleUI()
    {
        if (bottleUIPanel != null)
        {
            bottleUIPanel.SetActive(false);
        }
    }
}

// Script tambahan untuk mendefinisikan properti botol
public class Bottle : MonoBehaviour
{
    public string bottleName = "Botol Default";
    [TextArea]
    public string description = "Deskripsi botol";
}