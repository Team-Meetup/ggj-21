using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsicleController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool isJumping;
    private bool isFalling;

    public int iceCount;

    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float jumpForce = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;
        isJumping = false;
        iceCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        Vector2 targetVelocity = new Vector2(input.x * speed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .3f);

        Vector2 jumpVector = new Vector2(input.x, input.y * jumpForce);

        if (isJumping)
        {
            jumpVector.y = 0;
            Debug.Log("true");
        }
        else if(input.y > 0f)
        {
            jumpVector.y = input.y * jumpForce;
            isJumping = true;
            Debug.Log("false");
        }

        rb.AddForce(jumpVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("im grounded");
        }
    }
}
