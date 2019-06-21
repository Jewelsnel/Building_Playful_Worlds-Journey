using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Obstacle_manager : MonoBehaviour
{
    //Trigger
    private Collider2D trigger;

    // Obstacles
    public GameObject ObstacleOne;
    public GameObject ObstacleTwo;
    public GameObject ObstacleThree;

    //Bools
    private bool canPlay = true;
    private bool isDestroyed = false;
    private bool canDestroy;


    //Score
    public Score score;


    //Cutscene
    public PlayableDirector cutScene;

    //Animators
    public Animator obsOneAnim;
    public Animator obsTwoAnim;
    public Animator obsThreeAnim;


    // Start is called before the first frame update
    void Start()
    {
        cutScene = GetComponent<PlayableDirector>();

        obsOneAnim = obsOneAnim.GetComponent<Animator>();
        obsTwoAnim = ObstacleTwo.GetComponent<Animator>();
        obsThreeAnim = obsThreeAnim.GetComponent<Animator>();

        trigger = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
       if(Score.scoreAmount >= 1 && canPlay == true && canDestroy)
        {
            obsOneAnim.SetTrigger("isDead");
            cutScene.Play();
            canPlay = false;
            
        
        }

        if (Score.scoreAmount == 6 && isDestroyed == false)
        {

            obsTwoAnim.SetTrigger("isDead");
            isDestroyed = true;
        }

        if (Score.scoreAmount == 7 && isDestroyed == true)
        {

            obsThreeAnim.SetTrigger("isDead");
            isDestroyed = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
}
