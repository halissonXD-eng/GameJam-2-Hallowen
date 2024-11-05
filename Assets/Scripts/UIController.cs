using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public AudioClip clip;   
    public GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        //Este no se tiene que activar cuand este muerto
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }

    public void PlaySFXButton()
    {
        AudioManager.Instance.PlaySFX(clip);
    }
    public void SceneChange(string Scene)
    {
        GameManager.Instance.SceneChange(Scene);
    }
}
