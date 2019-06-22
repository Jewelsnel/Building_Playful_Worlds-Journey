using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        player = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Edge")
        {

            player.GetComponent<Player_movement>().canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Edge")
        {
            player.GetComponent<Player_movement>().canJump = false;
        }
    }

}
