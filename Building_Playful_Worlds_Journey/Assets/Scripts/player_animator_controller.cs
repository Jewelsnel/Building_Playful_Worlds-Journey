using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator_controller : MonoBehaviour
{

    private Animator myAnim;

    public bool isHurt = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            myAnim.SetBool("isRunning", true);
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetTrigger("attack");
        }

        if (isHurt == true) 
        {
            myAnim.SetTrigger("isHit");
            isHurt = false;
        }
        
    }

}

