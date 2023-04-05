using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
