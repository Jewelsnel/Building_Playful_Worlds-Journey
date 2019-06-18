using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class endgame_cutscene : MonoBehaviour
{


    public PlayableDirector cutScene;

    private Collider2D trigger;



    // Start is called before the first frame update
    void Start()
    {
        cutScene = GetComponent<PlayableDirector>();
        trigger = gameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        cutScene.Play();
        Destroy(trigger);


    }

}
