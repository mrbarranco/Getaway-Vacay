using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float uprightSpeed = 5f;
    public float jumpForce = 5f;
    private bool isRotating = false;
    private bool isUprighting = false;
    private float maxRotation = 55f;

    void Update()
    {
        float currentRotation =
            transform.eulerAngles.z > 180 ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;

        // Check if this is Player2
        if (gameObject.tag == "Player2")
        {
            // Rotate left with I key
            if (Input.GetKey(KeyCode.I) && currentRotation < maxRotation)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                isRotating = true;
            }
            // Rotate right with O key
            else if (Input.GetKey(KeyCode.O) && currentRotation > -maxRotation)
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                isRotating = true;
            }
        }
        else
        {
            // Rotate left with W key
            if (Input.GetKey(KeyCode.W) && currentRotation < maxRotation)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                isRotating = true;
            }
            // Rotate right with E key
            else if (Input.GetKey(KeyCode.E) && currentRotation > -maxRotation)
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                isRotating = true;
            }
        }

        // Check for key release
        if (
            isRotating
            && (
                (
                    gameObject.tag == "Player2"
                    && (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.O))
                )
                || (
                    gameObject.tag != "Player2"
                    && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.E))
                )
            )
        )
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isRotating = false;
        }
        if (!isRotating && !isUprighting)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0; // Stop spinning
        }
    }

    // write a method to upright the player after it touches the ground. (use a raycast)
}
