using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float fMoveSpeed = 40f;

    [Range(0, .3f)]
    [SerializeField]
    private float fMovementSmoothing = .05f;

    [SerializeField]
    private bool bReverseMovement = false;

    private float fHorizontalMovement = 0f;

    private Rigidbody2D rb;

    private Vector3 v3Velocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        fHorizontalMovement = Input.GetAxisRaw("Horizontal") * fMoveSpeed;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.bGameOver)
        {
            return;
        }

        Move();
    }

    void Move()
    {
        Vector3 targetVelocity = new Vector2(fHorizontalMovement * 10f * Time.deltaTime * (GameManager.instance.bReverseMovement ? -1 : 1), rb.velocity.y);

        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref v3Velocity, fMovementSmoothing);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag != "PlatformBase" && other.tag == "Ball")
        {
            if (bReverseMovement)
            {
                GameManager.instance.bReverseMovement = !GameManager.instance.bReverseMovement;
            }

            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;

            Destroy(this.gameObject, 2f);
        }
    }
}
