using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class END_level01_cutscene : MonoBehaviour
{



    public PlayableDirector cutScene;


    // Start is called before the first frame update
    void Start()
    {
        cutScene = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cutScene.Play();
    }

}
