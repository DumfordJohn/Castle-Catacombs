using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematicTransition : MonoBehaviour
{
    public float delay = 20f; // Time delay in seconds before changing scene
    private float timer = 0f; // Timer variable to keep track of time

    void Update()
    {
        timer += Time.deltaTime; // Increment timer by the time passed since last frame

        if (timer >= delay) // If the timer has exceeded the delay time
        {
            SceneManager.LoadScene("In-Game Scene"); // Load the scene with the specified name
        }
    }
}
