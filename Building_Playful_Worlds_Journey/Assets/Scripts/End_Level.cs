
using UnityEngine;

public class End_Level : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D()
    {
        gameManager.CompleteLevel();
    }
}
