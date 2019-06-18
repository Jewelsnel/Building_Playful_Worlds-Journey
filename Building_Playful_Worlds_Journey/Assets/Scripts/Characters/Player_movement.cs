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
        Vector3 movement = new Vector3(moveInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;  

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
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            
        }

        else if (canJump == false)
        {
            moveSpeed = 40;
        }

        if (canJump == true)
        {
            moveSpeed = 60;
        }



    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
