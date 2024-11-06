using System.Collections;
using System.Collections.Generic;
using TopDownCharacter2D.Controllers;
using UnityEngine;

public class GamePauseController : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource backgroundMusic;
    public GameObject pauseMenu;  

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

       
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame() // Detiene el juego
    {
        Time.timeScale = 0f;  
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);  // Activar el men� de pausa
        }
        isPaused = true;

        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();  // Pausa la m�sica
        }
    }

    public void ResumeGame() // Reanuda el juego
    {
        Time.timeScale = 1f;  // Reanudar el tiempo en el juego
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);  // Desactivar el men� de pausa
        }
        isPaused = false;

        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();  // Reanuda la m�sica
        }
    }
}
