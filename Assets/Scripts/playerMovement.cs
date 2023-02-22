using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jumpHight;
    public float rotationSpeed;
    public float rotationMin;
    public float rotationMax;
    public GameObject c;
    public GameObject p;
    // Update is called once per frame

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown (KeyCode.Space)) 
        { 
            if (transform.position.y <= 1.05)
            {
                GetComponent<Rigidbody>().AddForce (Vector3.up * jumpHight);
            }    
        }

        float mouseX = Input.GetAxis("Mouse X");
        p.transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        if (c.transform.localRotation.eulerAngles.y > rotationMin && c.transform.localRotation.eulerAngles.y < rotationMax)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            c.transform.Rotate(mouseY * rotationSpeed * Time.deltaTime, 0, 0);
        }
    }
}
