using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Obstacle_manager : MonoBehaviour
{
    // Obstacles
    public GameObject ObstacleOne;
    public GameObject ObstacleTwo;

    private bool canPlay = true;

    //Score
    public Score score;



    public PlayableDirector cutScene;

    // Start is called before the first frame update
    void Start()
    {
        cutScene = GetComponent<PlayableDirector>();

    }

    // Update is called once per frame
    void Update()
    {
       if(Score.scoreAmount >= 1 && canPlay == true)
        {
            cutScene.Play();
            canPlay = false;
            Destroy (ObstacleOne);
        
        }
    }
}
