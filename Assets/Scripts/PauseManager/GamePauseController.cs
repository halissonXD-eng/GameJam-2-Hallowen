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

    void PauseGame() // Detiene el juego
    {
        Time.timeScale = 0;  
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);  // Activar el menú de pausa
        }
        isPaused = true;

        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();  // Pausa la música
        }
    }

    void ResumeGame() // Reanuda el juego
    {
        Time.timeScale = 1;  // Reanudar el tiempo en el juego
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);  // Desactivar el menú de pausa
        }
        isPaused = false;

        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();  // Reanuda la música
        }
    }
}
