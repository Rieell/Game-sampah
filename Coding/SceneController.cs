using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Metode untuk mengatur aksi tombol "Play Again"
    public void PlayAgain()
    {
        // Muat ulang scene saat ini untuk memulai permainan kembali
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    // Metode untuk mengatur aksi tombol "Main Menu"
    public void MainMenu()
    {
        // Pindah ke scene "MainMenu" (gantilah "MainMenu" dengan nama scene menu utama Anda)
        SceneManager.LoadScene("MainMenu");
    }

    public void InGame()
    {
        // Pindah ke scene "MainMenu" (gantilah "MainMenu" dengan nama scene menu utama Anda)
        SceneManager.LoadScene("InGame");
    }
}