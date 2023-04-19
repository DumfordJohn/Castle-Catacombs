using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public Camera[] cameras;
    public AnimationClip[] clips;

    private int currentCameraIndex = 0;
    private int currentClipIndex = 0;

    private Animation currentAnimation;

    public float animationSpeed;

    private void Start()
    {
        // Set the initial camera and animation clip
        cameras[currentCameraIndex].gameObject.SetActive(true);
        currentAnimation = cameras[currentCameraIndex].GetComponent<Animation>();
        currentAnimation[clips[currentClipIndex].name].speed = animationSpeed;
        currentAnimation.clip = clips[currentClipIndex];
        currentAnimation.Play();
    }

    private void Update()
    {
        // Check if the current animation clip has finished playing
        if (!currentAnimation.isPlaying)
        {
            // Disable the current camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Move to the next camera and animation clip
            currentCameraIndex++;
            currentClipIndex++;
            if (currentCameraIndex >= cameras.Length || currentClipIndex >= clips.Length)
            {
                // End the cutscene
                EndCutscene();
            }
            else
            {
                // Activate the next camera and set its animation clip
                cameras[currentCameraIndex].gameObject.SetActive(true);
                currentAnimation = cameras[currentCameraIndex].GetComponent<Animation>();
                currentAnimation.clip = clips[currentClipIndex];
                currentAnimation.Play();
            }
        }
    }

    private void EndCutscene()
    {
        // Disable all cameras
        foreach (Camera camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        // Disable this cutscene controller
        gameObject.SetActive(false);
    }
}
