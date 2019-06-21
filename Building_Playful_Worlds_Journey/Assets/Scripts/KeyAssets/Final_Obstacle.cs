using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Obstacle : MonoBehaviour
{

    private Collider2D trigger;
    public Animator obsAnim;
    public GameObject obstacle;
    public Score score;
    public int scoreDeliverable;

    private bool canDestroy = false;



    void Start()
    {

        obsAnim = obstacle.GetComponent<Animator>();
        trigger = GetComponent<Collider2D>();
        score = gameObject.GetComponent<Score>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            canDestroy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            canDestroy = false;
        }

    }


    private void Update()
    {
        if(Score.scoreAmount == scoreDeliverable && canDestroy)
        {
           
            obsAnim.SetTrigger("isDead");
            Destroy(trigger);
            
        }
    }

}
