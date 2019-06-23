using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator_controller : MonoBehaviour
{

    private Animator myAnim;

    //Audio
    public AudioSource ouchSource;
    public AudioClip ouchClip;

    public AudioSource punchSource;
    public AudioClip punchClip;


    public bool isHurt = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        ouchSource.clip = ouchClip;
        punchSource.clip = punchClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            myAnim.SetBool("isRunning", true);

           
            //myAnim.ResetTrigger("attack");
        }
        else
        {
           myAnim.SetBool("isRunning", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetTrigger("attack");
            Punch();

        }

        if (isHurt == true) 
        {
            //myAnim.SetTrigger("isHit");
            StartCoroutine(Ouch());
            isHurt = false;
            myAnim.ResetTrigger("attack");
        }
        
    }

    IEnumerator Ouch()
    {
        myAnim.SetTrigger("isHit");
        ouchSource.Play();
        yield return new WaitForSeconds(0.2f);
        isHurt = false;
        myAnim.ResetTrigger("attack");

    }


    void Punch()
    {
        punchSource.Play();
    }

}

