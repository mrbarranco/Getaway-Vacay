using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 10f;
    private Transform playerTransform;

    void Start()
    {
        // Check if this is Player 1 Camera or Player 2 Camera
        if (gameObject.name == "Player 1 Camera")
        {
            // Find the player GameObject using its tag and get its transform
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (gameObject.name == "Player 2 Camera")
        {
            // Find the Player2 GameObject using its tag and get its transform
            playerTransform = GameObject.FindGameObjectWithTag("Player2").transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the target position for the camera
            Vector3 targetPosition = new Vector3(
                playerTransform.position.x,
                playerTransform.position.y,
                transform.position.z
            );

            // Interpolate between the camera's current position and the target position
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                followSpeed * Time.deltaTime
            );
        }
    }
}
