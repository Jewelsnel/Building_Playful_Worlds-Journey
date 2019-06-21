using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed;

    public float jumpHeight;
    public bool canJump = false;

    public bool facingRight = true;

    private Rigidbody2D rb;

    public GameObject gameOverUI;

    //private Animator myAnim;

    public float gravity = -15f;
    private Vector2 velocity;
    private Coroutine jumpRoutine;
    private bool applyGravity = true;
    public float drag = 0.99f;
    // Start is called before the first frame update
    void Start()
    {
        //myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveInput,0 , 0f);
        if (!canJump && applyGravity)
        {
            velocity += new Vector2(0, gravity * Time.deltaTime);
            velocity += new Vector2(0.1f * movement.x * moveSpeed, 0);
        }
        else if(canJump && applyGravity)
        {
            velocity += new Vector2(movement.x * moveSpeed, 0);
            velocity = new Vector2(velocity.x * drag, 0);
        }
        velocity = new Vector2(Mathf.Sign(velocity.x) * Mathf.Min(Mathf.Abs(velocity.x), Mathf.Abs(moveSpeed)), velocity.y);
        

        rb.velocity = velocity;

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }

        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }


        if(rb.position.y < -20f)
        {
            
        }
    }

    private void Jump()
    {


        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            if(jumpRoutine == null)
            {
                jumpRoutine = StartCoroutine(JumpRoutine());
            }

        }




    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator JumpRoutine()
    {
        applyGravity = false;
        velocity += new Vector2(0, jumpHeight);
        yield return new WaitForSeconds(0.2f);
        applyGravity = true;
        jumpRoutine = null;
    }

}
