using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float holdDuration = 2f; // Waktu yang diperlukan untuk hold
    private float holdTimer = 0f;

    private bool isInRange = false;
    private HoldProgressUI holdProgressUI;

    void Start()
    {
        // Cari UI di scene
        holdProgressUI = FindObjectOfType<HoldProgressUI>();
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKey(KeyCode.E))
            {
                holdTimer += Time.deltaTime;
                holdProgressUI.ShowProgress();
                holdProgressUI.UpdateProgress(holdTimer / holdDuration);

                if (holdTimer >= holdDuration)
                {
                    PickItem();
                }
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                ResetHold();
            }
        }
    }

    private void PickItem()
    {
        Debug.Log("Item picked up!");
        ResetHold();
        Destroy(gameObject); // Hapus item dari scene
    }

    private void ResetHold()
    {
        holdTimer = 0f;
        holdProgressUI.HideProgress();
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isInRange = true;
        Debug.Log("Player entered pickup range.");
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isInRange = false;
        Debug.Log("Player exited pickup range.");
    }
}

}