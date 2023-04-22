using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseQuit : MonoBehaviour
{
    public bool pauseQuit;

    void OnMouseUp()
    {
        if (pauseQuit)
        {
            SceneManager.LoadScene(0);
        }
    }

}