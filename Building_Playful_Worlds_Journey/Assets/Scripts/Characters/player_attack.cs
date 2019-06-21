using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask forestEnemies;
    public float attackRange;

    public float targetRange;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        startTimeBtwAttack -= Time.deltaTime;
        if (timeBtwAttack <= 0)
        {
            startTimeBtwAttack = Random.Range(1, 3);
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, forestEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Test_enemy>().TakeDamage(damage);
                }
            }
        
           //timeBtwAttack = startTimeBtwAttack;
        }
       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }



    /*attackTimer -= Time.deltaTime;
            if (attackTimer< -0)
            {

                
                attackTimer = Random.Range(4, 6);
                player_lives.health--;
                playeranim.isHurt = true;

            }*/
}
