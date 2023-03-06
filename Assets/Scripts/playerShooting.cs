using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public Animation reload;
    public float magSize;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            magSize -= 1;
            if (magSize > 0)
            {
                Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload.Play("Reload");
            magSize = 5;      
        }
    }
}
