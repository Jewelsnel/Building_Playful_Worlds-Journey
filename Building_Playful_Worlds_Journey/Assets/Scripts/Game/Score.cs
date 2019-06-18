using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    public static int scoreAmount = 0;


    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    //public void AddScore()
    // {
    //scoreText.text = scoreAmount + 1 .ToString();
    // Debug.Log(scoreAmount);
    //}

    public void Update()
    {
        scoreText.text = "" + scoreAmount;
    }

}
