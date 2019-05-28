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

    private float fHorizontalMovement = 0f;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector3 v3Velocity = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        fHorizontalMovement = Input.GetAxisRaw("Horizontal") * fMoveSpeed;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 targetVelocity = new Vector2(fHorizontalMovement * 10f * Time.deltaTime, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref v3Velocity, fMovementSmoothing);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            //other.gameObject.SetActive(false);
            anim.SetTrigger("Destroy");
            Destroy(this.gameObject, 2f);
        }
    }
}
