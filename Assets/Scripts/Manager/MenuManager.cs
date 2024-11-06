using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public AudioClip clipForButtons;
    public AudioClip MusicMenu;
    private void Start() 
    {
         PlayMusicScene(MusicMenu);
    }
    public void CambioEscena(string scene)
    {
        GameManager.Instance.SceneChange(scene);
    }
    public void PlaySFXbutton()
    {
        AudioManager.Instance.PlaySFX(clipForButtons);
    }
    public void PlayMusicScene(AudioClip MusicClip)
    {
         AudioManager.Instance.PlayMusic(MusicClip); 
    }

}
