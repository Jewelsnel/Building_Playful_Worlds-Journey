
using UnityEngine;

public class End_Level : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.CompleteLevel();
    }
}
