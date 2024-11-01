using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void CambioEscena(string scene)
    {
        GameManager.Instance.SceneChange(scene);
    }

}
