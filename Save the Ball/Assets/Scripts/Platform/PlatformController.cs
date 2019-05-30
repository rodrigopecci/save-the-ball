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
    private Vector3 v3LastTouchPosition;

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

        //Move();
        Touch();
    }

    void Move()
    {
        Vector3 targetVelocity = new Vector2(fHorizontalMovement * 10f * Time.deltaTime * (GameManager.instance.bReverseMovement ? -1 : 1), rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref v3Velocity, fMovementSmoothing);
    }

    void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 v3TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            v3TouchPosition.z = 0;

            if (touch.phase == TouchPhase.Began)
            {
                v3LastTouchPosition = v3TouchPosition;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = (v3TouchPosition - v3LastTouchPosition);
                transform.position = new Vector2((transform.position.x + direction.x * (GameManager.instance.bReverseMovement ? -2f : 2f)), transform.position.y);

                v3LastTouchPosition = v3TouchPosition;
            }
        }
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

enum PlatformType
{
    Retangle,
    Triangle
}
