using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed;

    public float jumpHeight;
    public bool canJump = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
             
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;  

        Jump();
            
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);


        }
    }

}
