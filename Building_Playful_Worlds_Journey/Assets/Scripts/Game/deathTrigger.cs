
using UnityEngine;

public class deathTrigger : MonoBehaviour
{
    public GameObject endLevelUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            endLevelUI.SetActive(true);
        }
            

    }
}
