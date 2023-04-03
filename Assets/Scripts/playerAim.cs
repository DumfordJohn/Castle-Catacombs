using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAim : MonoBehaviour
{
    public float sensitivity = 100f; // Sensitivity of mouse movement
    public float maxYAngle = 80f; // Maximum angle the player can look up/down

    private float currentYAngle = 0f; // Current angle the player is looking up/down

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y"); // Get the vertical movement of the mouse

        // Calculate the new angle the player should be looking up/down
        currentYAngle += mouseY * sensitivity * Time.deltaTime;
        currentYAngle = Mathf.Clamp(currentYAngle, -maxYAngle, maxYAngle); // Clamp the angle to prevent the player from looking too far up/down

        transform.localRotation = Quaternion.Euler(-currentYAngle, 0f, 0f); // Set the player's rotation based on the new angle
    }
}
