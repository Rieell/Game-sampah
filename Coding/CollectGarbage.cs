using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectGarbage : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject canvasGame;

    public AudioSource audioSource;
    public AudioClip audioTrash;
    public AudioClip audioWin;

    private int trashCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Pastikan objek yang menyentuh memiliki tag "Trash"
        if (other.CompareTag("Trash"))
        {
            // Tambahkan jumlah sampah
            trashCount++;

            // Hancurkan objek sampah
            Destroy(other.gameObject);

            // Perbarui skor pada UI Canvas
            
            scoreText.text = "Trash: " + trashCount.ToString();
            
            // Kondisi saat menang
            if (trashCount == 10 && canvasGame != null)
            {
                // Aktifkan ui dan suara
                canvasGame.SetActive(true);
                audioSource.PlayOneShot(audioWin);

                // Pause game
                Time.timeScale = 0;
            }

            // Tampilkan jumlah trash di konsol
            Debug.Log("Total trash collected: " + trashCount);

            // Mengaktifkan suara
            audioSource.PlayOneShot(audioTrash);
        }
    }
}