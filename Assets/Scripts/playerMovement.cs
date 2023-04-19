using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jumpHight;
    public float rotationSpeed;
    public float groundCheckDistance = 1.05f;
    private float distanceToGround;
    public float jumpCooldown = 0.5f; // Time in seconds before the player can jump again
    private float lastJumpTime; // Time when the player last jumped
    private bool isGrounded;
    public GameObject c;
    public GameObject p;

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


        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && (Time.time - lastJumpTime) > jumpCooldown)
        {
            // Get the distance to the ground
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                distanceToGround = hit.distance;
            }

            // Perform the jump
            if (distanceToGround <= groundCheckDistance)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHight, ForceMode.Impulse);
                lastJumpTime = Time.time;
            }
        }

        float mouseX = Input.GetAxis("Mouse X");
        p.transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }
}
