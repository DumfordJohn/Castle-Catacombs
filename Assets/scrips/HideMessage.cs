using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMessage : MonoBehaviour
{
    public float after = 5.0f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(after);
        gameObject.SetActive(false);
    }
}
