using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Obstacle : MonoBehaviour
{
    public Score score;
    public Animator obstacle;

    public bool canDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        obstacle = obstacle.GetComponent<Animator>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log(canDestroy);
            canDestroy = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            canDestroy = false;
        }
    }


    // Update is called once per frame
    /*void Update()
    {
        if(Score.scoreAmount == 9 && canDestroy)
        {
            obstacle.SetTrigger("isDead");
            canDestroy = false;
        }
    }*/


}
