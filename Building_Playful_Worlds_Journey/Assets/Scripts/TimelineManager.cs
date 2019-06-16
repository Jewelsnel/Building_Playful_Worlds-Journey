using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private bool fix = false;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    public Camera mainCamera;


    // Start is called before the first frame update
    void OnEnable()
    {
        playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;

        mainCamera = mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing && !fix)
        {
            fix = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            director.Stop();
            mainCamera.transform.localPosition = new Vector3(0, 5, -10);
        }
    }
}
