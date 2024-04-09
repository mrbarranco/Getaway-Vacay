using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float tiltSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public GameObject pivot;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private float tiltDirection = 0;

    void Start()
    {
        // Find the "Shoe" object
        Transform shoeTransform = transform.Find("Shoe");
        if (shoeTransform == null)
        {
            Debug.LogError("Shoe object not found");
            return;
        }

        // Set the pivot's position to the "Shoe" object's position
        pivot.transform.position = shoeTransform.position;

        // Set the player's parent to the pivot
        transform.SetParent(pivot.transform);

        // Get the rigidbody component from the pivot
        rb = pivot.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            tiltDirection = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            tiltDirection = 1;
        }

        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.W))
        {
            float tiltAngle = tiltSpeed * tiltDirection;
            float newRotationZ = Mathf.Clamp(transform.eulerAngles.z + tiltAngle, -45f, 45f);
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                newRotationZ
            );
        }

        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.W))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Fire();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation
        );
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 2.0f);
    }
}
