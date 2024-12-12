using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject interaction_Info_UI;
    private TextMeshProUGUI interaction_text;
 
    private void Start()
    {
        // Tambahkan null check sebelum mengambil komponen
        if (interaction_Info_UI != null)
        {
            interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("Interaction Info UI tidak di-assign di Inspector!");
        }
    }
 
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        // Tambahkan null check untuk interaction_Info_UI dan interaction_text
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            if (selectionTransform != null && 
                selectionTransform.GetComponent<InteractableObject>() != null)
            {
                if (interaction_Info_UI != null && interaction_text != null)
                {
                    var interactableObject = selectionTransform.GetComponent<InteractableObject>();
                    interaction_text.text = interactableObject.GetItemName();
                    interaction_Info_UI.SetActive(true);
                }
            }
            else 
            { 
                if (interaction_Info_UI != null)
                {
                    interaction_Info_UI.SetActive(false);
                }
            }
        }
    }
}