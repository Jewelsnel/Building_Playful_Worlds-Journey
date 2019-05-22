using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator_controller : MonoBehaviour
{

    public Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerHurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        //Ignore with Enemies
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);
        // Loop blinking
        myAnim.SetLayerWeight(1, 1);
        //Wait invincibility
        yield return new WaitForSeconds(hurtTime);
        //Stop blinking animation

        //Re-enable collision
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        myAnim.SetLayerWeight(1, 0);
    }
}

