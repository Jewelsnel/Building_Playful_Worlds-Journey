using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Obstacle_manager : MonoBehaviour
{
    // Obstacles
    public GameObject ObstacleOne;
    public GameObject ObstacleTwo;
    public GameObject ObstacleThree;

    private bool canPlay = true;
    private bool isDestroyed = false;


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

    }

    // Update is called once per frame
    void Update()
    {
       if(Score.scoreAmount >= 1 && canPlay == true)
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
}
