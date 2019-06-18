using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_gameOver : MonoBehaviour
{
    public Score score;

    void EndLevel()
    {
        Score.scoreAmount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
