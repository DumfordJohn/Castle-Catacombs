using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPopup : MonoBehaviour
{
    public float after = 5.0f;

    void Start()
    { 
        Invoke("Disable", after);
    }

    void Disable()
    { 
        gameObject.SetActive(false);
    }
}
