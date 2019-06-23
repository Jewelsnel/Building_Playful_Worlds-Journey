using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Score score;


    public float restartDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            Restart();
        }
    }

    public void Restart()
    {
        Score.scoreAmount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
