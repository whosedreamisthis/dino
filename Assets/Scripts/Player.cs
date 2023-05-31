using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] float gravity = 9.81f * 2f;
    [SerializeField] float jumpForce = 8;

    bool isGrounded = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * jumpForce;
            rb.AddForce(direction);
            Debug.Log("dir " + direction.y);

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
