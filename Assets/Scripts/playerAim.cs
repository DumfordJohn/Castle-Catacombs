using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class playerAim : MonoBehaviour
{
    public float rotationSpeed;

    public float rotationMin;
    public float rotationMax;

    public GameObject c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (c.transform.localRotation.eulerAngles.y > rotationMin && c.transform.localRotation.eulerAngles.y < rotationMax)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            c.transform.Rotate(-mouseY * rotationSpeed * Time.deltaTime, 0, 0);
        }

    }
}
